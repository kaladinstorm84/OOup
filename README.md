# OOup
A c# Task based deployment framework

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
