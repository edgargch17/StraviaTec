using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTEC_Backend.Models
{   /**<summary></summary>*/
    public class Activity
    {
        public string id { get; set; } //Primary Key
        public string category { get; set; }//?
        public string type { get; set; }
        public string duration { get; set; }
        public string distance { get; set; }
        public DateTime dateTime { get; set; }
        public string map { get; set; }
        public string challenge_race { get; set; }
    }
}
