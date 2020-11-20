using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StraviaTEC_Backend.Consults;
using StraviaTEC_Backend.Models;
using StraviaTEC_Backend.DataBaseAccess;
using Npgsql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaTEC_Backend.Controllers
{
    [Route("api/view")]
    [ApiController]
    public class ViewsController : ControllerBase
    {
        // GET: api/<ViewsController>
        [HttpGet("{username}")]
        [Route ("friends")]
        //public IEnumerable<Athlete> getFriends(string username)
        public void getFriends(string username)
        {
            List<Athlete> friends = new List<Athlete>();
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(DataBaseConstants.dataBaseConnection);
                connection.Open();
                string query = @"SELECT friend_id FROM athlete INNER JOIN athlete_friend ON '" + username + "'= athlete_friend.athlete_id WHERE athlete.username = athlete_friend.athlete_id";
                NpgsqlCommand connector = new NpgsqlCommand(query, connection);
            }
            catch { }
        }

        // GET api/<ViewsController>/5
        //[HttpGet("{race_identifier}")]
        [HttpGet]
        [Route("race")]
        public IEnumerable<race_athlete> Get(string race_identifier)
        {
            List<race_athlete> race_Athletes = new List<race_athlete>();
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(DataBaseConstants.dataBaseConnection);
                connection.Open();
                string query = @"SELECT category.category_name, athlete.full_name, athlete.age, category.race_id
                                FROM race INNER JOIN category ON category.race_id = race.race_identifier 
                                INNER JOIN athlete_race ON athlete_race.race_id = category.race_id 
                                INNER JOIN athlete ON athlete.username = athlete_race.athlete_id ";
                NpgsqlCommand connector = new NpgsqlCommand(query, connection);
                NpgsqlDataReader reader = connector.ExecuteReader();
                while (reader.Read())
                {
                    race_Athletes.Add(new race_athlete
                    {
                        category_name = (string)reader["category_name"],
                        full_name = (string)reader["full_name"],
                        race_id = (string)reader["race_id"],
                        age = (int)reader["age"]
                    });
                }
            }
            catch { }

            return race_Athletes;
        }
        

        
    }
}
