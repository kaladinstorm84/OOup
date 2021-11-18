# OOup
A c# Task based deployment pipeline framework. Designed to allow you to control the deployment of the application, in the language it was written - without the need for 'frustrating' YAML pipeline files

## usage
    using OOup.Tasks;

    OOup.Tasks.TaskManager manager = new OOup.Tasks.TaskManager()
    {
        { new CommandLine("ipconfig", "/all") },
        { new CommandLine("dir","") },
        { new SetWorkingDirectory("C:\\") },
        { new CommandLine("dir","") }
    };

    OOup.OOupDeploy.Deploy(manager);
