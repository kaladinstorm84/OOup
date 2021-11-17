using System.Text;

namespace OOup.Statuses
{
    public class ExecuteStatus
    {
        public Status Status { get; set; } = Status.InProgress;
        public StringBuilder Output { get; set; } = new StringBuilder();
    }
}
