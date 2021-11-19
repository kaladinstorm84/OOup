using OOup.Interfaces;
using OOup.Statuses;
using OOup.Tasks.TaskBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOup.Tasks
{
    public class ForEach<T> : BaseTask
    {
        public ForEach(IEnumerable<T> items, Func<T, BaseTask> action)
        {
            Items = items;
            Action = action;
        }

        public IEnumerable<T> Items { get; }
        public Func<T, BaseTask> Action { get; }

        public override void Run()
        {
            foreach(T item in Items)
            {
                BaseTask task = Action(item);
                task.Execute();
                WriteToStatus(task.ExecStatus.Output.ToString(),task.ExecStatus.Status);

            }
        }
    }
}
