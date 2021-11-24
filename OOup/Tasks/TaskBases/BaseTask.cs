using OOup.Interfaces;
using OOup.Library;
using OOup.Statuses;

namespace OOup.Tasks.TaskBases
{
    public abstract class BaseTask : LoggingTask, ITask
    {
        public override ExecuteStatus ExecStatus { get; set; } = new ExecuteStatus();
        public string StepName { get; set; } = "";

        protected BaseTask() : base()
        {
        }

        public abstract void Run();
        public ExecuteStatus Execute()
        {
            Run();
            VariableLibrary.Parse(ExecStatus);
            if (ExecStatus.Status == Status.InProgress)
                ExecStatus.Status = Status.Completed;
            return ExecStatus;
        }
    }
}
