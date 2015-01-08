using Mobat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobat.Adapters
{
    interface IProfileAdapter
    {
        ProfileViewModel GetProfileViewModel(string userId);
        void UpdateProfileViewModel(ProfileViewModel data, string userId);
    }
}
