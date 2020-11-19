using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTEC_Backend.Models
{   /**<summary></summary>*/
    public class Activity
    {

        public string category { get; set; }
        public string type_act { get; set; }
        public TimeSpan duration { get; set; }
        public int distancia { get; set; } //Kilometer
        public DateTime date_time { get; set; }
        public string map { get; set; }
        public string challenge_race { get; set; }
        public string activity_identifier { get; set; } //Primary Key
    }
}
