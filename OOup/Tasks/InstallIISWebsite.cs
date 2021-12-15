namespace OOup.Tasks
{
    public class InstallIISWebsite : RunPowershellIIS
    {
        public override string Script => "[CmdletBinding()]Param([string] $appName, [string] $appPool, [string] $Path) Import-Module WebAdministration; New-WebSite -Name $appName -ApplicationPool $appPool -PhysicalPath $Path";
        public InstallIISWebsite(string WebsiteName, string appPool, string directory) : base(WebsiteName, appPool, directory)
        {
        }
    }
}
