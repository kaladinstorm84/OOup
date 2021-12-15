namespace OOup.Tasks
{
    public class InstallIISWebApp : RunPowershellIIS
    {
        public override string Script => "[CmdletBinding()]Param([string] $site,[string]$name, [string] $appPool, [string] $Path) Import-Module WebAdministration; New-WebApplication -Site $site -Name $name -ApplicationPool $appPool -PhysicalPath $Path";
        public InstallIISWebApp(string site, string name, string appPool, string directory) : base(site, name, appPool, directory)
        {
        }
    }
}
