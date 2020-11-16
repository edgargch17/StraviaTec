using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTEC_Backend.Models
{   
    /**<summary>CLASE QUE SE ENCARGA DE MODELAR LA ENTIDAD DE DEPORTISTA EN LA BASE DE DATOS Y PERMITE EL 
     * ACCESO DE DATOS DESDE EL FRONTEND</summary>
     */
    public class Athlete
    {
        /**<summary> ATHLETE CLASS ATTRIBUTES</summary>*/
        public string username { get; set; }//Primary Key
        public string password { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public string nationality { get; set; }
        public DateTime birth_date { get; set; }
        public string photo { get; set; }
        public int age { get; set; }

        public void setAge()
        {
            this.age = DateTime.Today.Year - this.birth_date.Year;
        }/**/

        public int getAge()
        {
            return this.age;
        }


    }
}
