using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTEC_Backend.Models
{
    public class Race
    {
        public string race_name { get; set; }
        public string travel { get; set; }//(GPX)
        public DateTime race_date { get; set; }
        public int money_cost { get; set; }
        public string activity_type { get; set; }
        public string race_identifier { get; set; }// PRIMARY KEY
        public string activity_id { get; set; }
    }
}
