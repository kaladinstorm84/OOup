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
    public class RunPowershell : BaseTask
    {
        public RunPowershell(string inlineScript, params string [] args) :base()
        {
            this.ScriptLocation = inlineScript;
            Args = args;
        }

        public string ScriptLocation { get; }
        public string[] Args { get; }

        public override void Run()
        {
            using (PowerShell powerShell = PowerShell.Create())
            {
                powerShell.AddScript(ScriptLocation).AddArgument(Args);
                Collection<PSObject> PSOutput = powerShell.Invoke();
                foreach (PSObject pSObject in PSOutput)

                if (powerShell.HadErrors)
                {
                    WriteToStatus(pSObject.ToString(),type:MessageType.Error);
                    Fail();
                }
                else
                {
                        WriteToStatus(pSObject.ToString(), type: MessageType.Info);
                        Complete();
                }
            }
        }
    }
}
