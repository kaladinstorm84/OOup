# OOup
A c# Task based deployment pipeline framework. Designed to allow you to control the deployment of the application, in the language it was written - without the need for 'frustrating' YAML pipeline files

## usage
    using OOup.Tasks;

	List<string> directories = new List<string>()
	{
		"c:\\", "c:\\shared"
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
		{ new InstallIISWebsite("TestSite2","TestPoolDeploy","C:\\inetpub\\wwwroot") }

	};

	OOup.OOupDeploy.Deploy(taskList);

Nuget available at https://www.nuget.org/packages/OOup/
