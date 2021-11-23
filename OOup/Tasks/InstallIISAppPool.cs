using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOup.Tasks
{
    public class InstallIISAppPool : RunPowershell
    {
        const string inlineScript = "Param([string] $AppPoolName)if (!(Test-Path IIS:\\AppPools\\$AppPoolName -pathType container)){Write-Output \"Create the app pool\" ; $appPool = New-WebAppPool -Name $AppPoolName -Force}}";
        public InstallIISAppPool(string appPool, string directory) : base(inlineScript, appPool, directory)
        {
        }
    }
}
