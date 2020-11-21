using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using StraviaTEC_Backend.DataBaseAccess;

namespace StraviaTEC_Backend.Tools
{
    public class Connector
    {
        private DataBaseHandler dataBaseHandler = new DataBaseHandler();
        //private static NpgsqlConnection connection = new NpgsqlConnection(DataBaseConstants.dataBaseConnection);

        public bool savePhoto(string username, string path)
        {
            try
            {
                dataBaseHandler.updateDataBase(DataBaseConstants.athlete, "photo = '" + path + "'", "username = '" + username + "'");
                return true;
            }
            catch { }
            return false;
            /*using (NpgsqlCommand cmd = new NpgsqlCommand("\"UploadPhotoPath\"", connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("_token", token);
                cmd.Parameters.AddWithValue("_path", path);
                bool result = (bool)cmd.ExecuteScalar();

                connection.Close();

                return result;
            }*/

        }/**/

        /*public static string getPhotoPath(string token)
        {
            connection.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("\"GetPhotoPath\"", connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_token", token);
                string result = (string)cmd.ExecuteScalar();

                connection.Close();

                return result;
            }
        }*/
    }
}
