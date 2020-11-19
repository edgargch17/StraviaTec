using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTEC_Backend.Models
{
    public class Challenge
    {
        public string description { get; set; }
        public string name_challenge { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string type_challenge { get; set; }
        public string activity_id { get; set; }
        public string challenge_identifier { get; set; } //PRIMARY KEY
        
    }
}
