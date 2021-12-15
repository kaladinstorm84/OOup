using OOup.Statuses;

namespace OOup.Tasks.TaskBases
{
    public abstract class LoggingTask
    {
        protected Action<string> logging;
        public abstract ExecuteStatus ExecStatus { get; set; }
        protected LoggingTask()
        {
            logging = Console.WriteLine;
        }

        protected void Complete()
        {
            WriteToStatus("Completed", Status.Completed, MessageType.Pass);
        }

        protected void Fail(string? Message = null)
        {
            WriteToStatus($"{ Message ?? "Failed"}", Status.Failed, MessageType.Error);
        }
        protected void Log(string message)
        {
            logging(message);
        }
        
        protected void WriteToStatus(string Message, Status state=Status.InProgress, MessageType type = MessageType.Info)
        {
            string color = "";
            switch (type)
            {
                case MessageType.Warn: color = "\u001b[38;5;208m"; break;
                case MessageType.Error: color = "\u001b[38;5;9m"; break;
                case MessageType.Pass: color = "\u001b[38;5;10m"; break;
                default: color = "\u001b[0m"; break;
            }
            ExecStatus.Output.AppendLine($"{DateTime.Now} : {color}{Message}\u001b[0m");
            if (ExecStatus.Status != Status.Failed)
            {
                ExecStatus.Status = state;
            }
        }
    }
}