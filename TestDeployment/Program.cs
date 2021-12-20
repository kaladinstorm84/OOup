using OOup;
using OOup.DataObjects;
using OOup.Tasks;
List<string> directories = new List<string>()
{
    "c:\\", "c:\\shared"
};
DatabaseConnection connection = new DatabaseConnection()
{
    UserName = ""
};

TaskList taskList = new TaskList()
{
    { new CommandLine("ipconfig", "/all") },
    { new CommandLine("dir","") },
    { new SetWorkingDirectory("C:\\") },
    { new CommandLine("dir","") },
    { new ForEach<string>(directories, d => new SetWorkingDirectory(d) ) },
    { new CommandLine("dir","") },
    { new InstallIISAppPool("TestPoolDeploy") },
    { new InstallIISWebsite("TestSite2","TestPoolDeploy","C:\\inetpub\\wwwroot") },
    { new RunSQLFile("", connection) }
};

OOupDeploy.Deploy(taskList);
