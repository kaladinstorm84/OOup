using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOup.Tasks
{
    public class InstallIISAppPool : RunPowershellIIS
    {
        public override string Script { get {
                StringBuilder script = new StringBuilder();
                script.AppendLine("[CmdletBinding()]");
                script.AppendLine("Param");
                script.AppendLine("([string] $AppPoolName)");
                script.AppendLine("if (!(Test-Path IIS:\\AppPools\\$AppPoolName -pathType container))");
                script.AppendLine("{");
                script.AppendLine("Import-Module WebAdministration;");
                script.AppendLine("Write-Output \"Create the app pool\" ;");
                script.AppendLine("$appPool = New-WebAppPool -Name $appPoolName;");
                script.AppendLine("$appPool");
                script.AppendLine("}");
                return script.ToString();
            }
        }
        public InstallIISAppPool(string appPool): base(appPool)
        {
         
        }
    }
}
