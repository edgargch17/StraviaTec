using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTEC_Backend.Models
{
    public class Sponsor
    {
        public string tradename { get; set; }//Primary Key
        public string logo { get; set; }//Imagen
        public PhoneAttribute phone { get; set; }//Telefono
        public string legal_representative { get; set; }
    }
}
