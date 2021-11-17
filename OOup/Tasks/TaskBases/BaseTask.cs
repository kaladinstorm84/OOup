using OOup.Interfaces;
using OOup.Statuses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOup.Tasks.TaskBases
{
    public abstract class BaseTask : LoggingTask, ITask
    {
        protected override ExecuteStatus ExecStatus { get; set; } = new ExecuteStatus();
        public string StepName { get; set; } = "";

        protected BaseTask() : base()
        {
        }

        public abstract void Run();
        public ExecuteStatus Execute()
        {
            Run();
            if (ExecStatus.Status == Status.InProgress)
                ExecStatus.Status = Status.Completed;
            return ExecStatus;
        }
    }
}
