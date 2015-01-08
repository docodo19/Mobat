using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mobat.Models
{
    public class LogViewModel
    {
        public int Id { get; set; }
        public bool Victory { get; set; }
        public int TimePlayed { get; set; }
        public string Comment { get; set; }
        public int GameId { get; set; }
    }
}