using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTEC_Backend.Models
{
    public class Challenge
    {
        public string challenge_id { get; set; }
        public string fond_high { get; set; }
        public string type { get; set; }
        public TimeSpan available_time { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
