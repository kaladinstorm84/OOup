using OOup.Statuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOup.Tasks
{
    public static class TaskSettings
    {
        public static string CurrentWorkingDirectory { get; set; }
        static TaskSettings()
        {
            CurrentWorkingDirectory = Directory.GetCurrentDirectory(); 
        }
    }
    public class SetWorkingDirectory : TaskBases.BaseTask
    {
        string workingDirectory;

        public SetWorkingDirectory(string workingDirectory)
        {
            this.workingDirectory = workingDirectory;
        }

        public override void Run()
        {
            TaskSettings.CurrentWorkingDirectory = workingDirectory;
            WriteToStatus($"Working Directory Changed to : {workingDirectory}",type: TaskBases.MessageType.Warn);
        }
    }
}
