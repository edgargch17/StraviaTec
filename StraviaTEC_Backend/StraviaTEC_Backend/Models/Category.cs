using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTEC_Backend.Models
{
    public class Category
    {
        public string race_id { get; set; }
        public string category_name { get; set; } //PRIMARY KEY
        public string description { get; set; }
    }
}
