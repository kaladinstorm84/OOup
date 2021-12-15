using Newtonsoft.Json;
using OOup.Tasks.TaskBases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace OOup.Tasks
{
    public abstract class RunPowershellIIS : RunPowershell
    {
        
        public RunPowershellIIS(string ScriptLocation, params string[] args) : base( args)
        {
        }


        public override void Run()
        {
            Runspace rs;
            using (PowerShell powerShell = PowerShell.Create())
            {

                powerShell.AddScript("Enable-WindowsOptionalFeature -Online -FeatureName IIS-WebServerRole, IIS-WebServer, IIS-CommonHttpFeatures, IIS-ManagementConsole, IIS-HttpErrors, IIS-HttpRedirect, IIS-WindowsAuthentication, IIS-StaticContent, IIS-DefaultDocument, IIS-HttpCompressionStatic, IIS-DirectoryBrowsing");
                powerShell.AddStatement().AddCommand("Write-Host").AddArgument("IIS Set Up Complete");
                Collection<PSObject> PSOutput = powerShell.Invoke();
                foreach (PSObject pSObject in PSOutput)
                {
                    WriteToStatus(JsonConvert.SerializeObject(pSObject));
                    foreach (var d in powerShell.Streams.Error)
                    {
                        WriteToStatus(d.Exception.Message);
                        if (d.ErrorDetails != null)
                        {
                            WriteToStatus(d.ErrorDetails.Message);
                        }
                    }


                    if (powerShell.HadErrors)
                    {
                        WriteToStatus(pSObject.Properties.ToArray().ToString(), type: MessageType.Error);
                        Fail();
                    }
                    else
                    {
                        WriteToStatus(pSObject.Properties.ToArray().ToString(), type: MessageType.Info);
                        Complete();
                    }
                }

            }

            base.Run();
        }
    }
}
