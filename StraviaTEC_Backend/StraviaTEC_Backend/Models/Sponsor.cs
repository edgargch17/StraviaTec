using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTEC_Backend.Models
{
    public class Sponsor
    {
        public string legal_represent { get; set; }
        public string logo { get; set; }//Picture
        public string phone { get; set; }
        public string tradename { get; set; }//Primary Key
    }
}
