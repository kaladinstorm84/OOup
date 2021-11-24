using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOup.Tasks
{
    public class InstallIISWebsite : RunPowershell
    {
        const string inlineScript = "Param([string] $appName, [string] $appPool, [string] $Path) New-WebApplication $appName -Site $appName -ApplicationPool $appPool -PhysicalPath $Path";
        public InstallIISWebsite(string WebsiteName, string appPool, string directory) : base(inlineScript, WebsiteName, appPool, directory)
        {
        }
    }
}
