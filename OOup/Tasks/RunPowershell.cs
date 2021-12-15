using Newtonsoft.Json;
using OOup.Tasks.TaskBases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace OOup.Tasks
{
    /// <summary>
    /// Pass an Inline script to the Powershell host
    /// 
    /// Variables will be captured if written to Host as [%VariableName%]=Value
    /// </summary>
    public abstract class RunPowershell : BaseTask
    {
        public abstract string Script { get; }
        public string? Command { get; set; } = null;
        public RunPowershell(params string[] args) : base()
        {
            Args = args;
        }
        public RunPowershell(string script, params string[] args) : base()
        {
            Command = script;
            Args = args;
        }

        public string[] Args { get; }

        public override void Run()
        {
            
            using (PowerShell powerShell = PowerShell.Create())
            {
                powerShell.AddScript(Command ?? Script);
                foreach (string arg in Args)
                {
                    powerShell.AddArgument(arg);
                }
                Collection<PSObject> PSOutput = powerShell.Invoke();
                foreach (PSObject pSObject in PSOutput)
                {
                    WriteToStatus(JsonConvert.SerializeObject(pSObject), type: MessageType.Info);
                    if (powerShell.HadErrors)
                    {
                        Fail();
                    }
                    else
                    {
                        Complete();
                    }
                }
                foreach (var d in powerShell.Streams.Error)
                {
                    WriteToStatus(d.Exception.Message);
                    if (d.ErrorDetails != null)
                    {
                        WriteToStatus(d.ErrorDetails.Message,type: MessageType.Error);
                    }
                }


            }
        }
    }
}
