using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTEC_Backend.Models
{
    public class Challenge
    {
        public string challenge_id { get; set; }
        public string deep_high { get; set; }
        public string type_challenge { get; set; }
        public TimeSpan available_time { get; set; }
        public string name_challenge { get; set; }
        public string description { get; set; }
    }
}
