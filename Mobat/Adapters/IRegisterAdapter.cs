using Mobat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobat.Adapters
{
    public interface IRegisterAdapter
    {
        void CreateUser(RegisterViewModel data);
    }
}
