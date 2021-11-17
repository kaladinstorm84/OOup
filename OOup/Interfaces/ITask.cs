using OOup.Statuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOup.Interfaces
{
    public interface ITask
    {
        ExecuteStatus Execute();
        void Run();
    }
}
