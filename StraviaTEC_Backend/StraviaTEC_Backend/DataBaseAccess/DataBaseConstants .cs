using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTEC_Backend.DataBaseAccess
{
    static class DataBaseConstants
    {
        /**<summary>COMMAND TO START CONNECTION WITH DATABASE</summary>**/
        public static string dataBaseConnection= "Server = localhost; User Id = postgres; Password = 2659; Database = postgres";

        /**<summary>COMMAND LIST THAT WILL MANIPULATE DATA IN DB </summary>**/
        public static string select = "SELECT";
        public static string from = "FROM";
        public static string where = "WHERE";
        public static string set = "SET";
        public static string group_by = "GROUP BY"; 


        /**<summary>TABLE NAME CONSTANTS IN DB</summary>**/
        public static string athlete = "athlete";
        public static string sponsor = "SPONSOR";
        public static string activity = "ACTIVITY";
        public static string race = "RACE";
        public static string challenge = "CHALLEGE";
        public static string team = "TEAM";

        /**<summary>ATTRIBUTE LIST FOR EACH TABLE IN DB</summary>**/
        //TABLE ATHLETE ATTRIBUTES
        public static string username = "USERNAME";
        public static string password = "PASSWORD";
        public static string name = "NAME";
        public static string last_name = "LAST_NAME";
        public static string nationality = "NACIONALITY";
        public static string birth_date = "BIRTH_DATE";
        public static string photo = "PHOTO";
        public static string age = "AGE";
    }

    
}
