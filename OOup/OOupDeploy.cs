using OOup.Interfaces;
using OOup.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOup
{
    public static class OOupDeploy
    {
        public static void Deploy(TaskManager taskCollection)
        {
            foreach (KeyValuePair<int, ITask> item in taskCollection.OrderBy(a => a.Key))
            {
                Console.WriteLine($"Running Task : {item.Key}");
                Console.WriteLine($"Task Type    : {item.Value.GetType().Name} ");
                var result = item.Value.Execute();
                Console.WriteLine(result.Status.ToString());
                Console.WriteLine(result.Output.ToString());
                Console.WriteLine("----------------------");
            }

        }
    }
}
