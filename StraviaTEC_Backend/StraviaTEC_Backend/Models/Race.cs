using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTEC_Backend.Models
{
    public class Race
    {
        public string race_id { get; set; }
        public string activity_type { get; set; }
        public int cost { get; set; }
        public string bank_accounts { get; set; }
        public DateTime date { get; set; }
        public string travel { get; set; }//(GPX)
        public string name { get; set; }
        public string category { get; set; }

    }
}
