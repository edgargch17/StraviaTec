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
        public int money_cost { get; set; }
        public string bank_accounts { get; set; }
        public DateTime date_act { get; set; }
        public string travel { get; set; }//(GPX)
        public string name_act { get; set; }
        public string category { get; set; }

    }
}
