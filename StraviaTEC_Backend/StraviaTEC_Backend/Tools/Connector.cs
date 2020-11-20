using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using StraviaTEC_Backend.DataBaseAccess;

namespace StraviaTEC_Backend.Tools
{
    public static class Connector
    {
        private static NpgsqlConnection connection = new NpgsqlConnection(DataBaseConstants.dataBaseConnection);

            public static bool savePhoto(string token, string path)
            {
                connection.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("\"UploadPhotoPath\"", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_token", token);
                    cmd.Parameters.AddWithValue("_path", path);
                    bool result = (bool)cmd.ExecuteScalar();

                    connection.Close();

                    return result;
                }

            }   

        public static string getPhotoPath(string token)
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
        }
    }
}
