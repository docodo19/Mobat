using Mobat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobat.Adapters
{
    interface ILogAdapter
    {
        List<LogViewModel> GetLogViewModel(string userId, int id);

        void RemoveLog(int Id);

        void AddLog(LogViewModel model);
    }
}
