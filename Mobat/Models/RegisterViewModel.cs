using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mobat.Models
{
    public class RegisterViewModel
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarUrl { get; set; }


    }
}