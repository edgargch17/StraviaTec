using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StraviaTEC_Backend.Models;
using StraviaTEC_Backend.DataBaseAccess;
using Npgsql;

namespace StraviaTEC_Backend.Controllers
{
    [Route("api/search")]
    ///[ApiController]
    public class searchController : ControllerBase
    {
        //DataBaseHandler dataBaseHandler = new DataBaseHandler();
        [HttpPost]
        public IEnumerable<Athlete> searchAthletes([FromBody] string name)
        {
            List<Athlete> athletes = new List<Athlete>();
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(DataBaseConstants.dataBaseConnection);
                connection.Open();
                string query = "SELECT * FROM athlete WHERE full_name LIKE '%" + name + "%'";
                NpgsqlCommand connector = new NpgsqlCommand(query, connection);
                NpgsqlDataReader reader = connector.ExecuteReader();
                while (reader.Read())
                {
                    athletes.Add(
                       new Athlete()
                       {
                           username = (string)reader["username"],
                           password = (string)reader["password"],
                           full_name = (string)reader["full_name"],
                           nationality = (string)reader["nationality"],
                           birth_date = (DateTime)reader["birth_date"],
                           photo = (string)reader["photo"],
                           age = (int)reader["age"]
                       });
                }
            }
            catch
            {

            }
            return athletes;
        }

    }

        
}
