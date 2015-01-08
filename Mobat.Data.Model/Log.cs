using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobat.Data.Model
{
    public class Log
    {
        public int Id { get; set; }
        public bool Victory { get; set; }
        public int TimePlayed { get; set; }
        public string Comment { get; set; }

        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
    }
}
