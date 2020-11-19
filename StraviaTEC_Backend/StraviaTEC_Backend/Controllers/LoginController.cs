using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StraviaTEC_Backend.DataBaseAccess;
using StraviaTEC_Backend.Models;
using Npgsql;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaTEC_Backend.Controllers
{
    [Route("api/login")]
    //[ApiController]
    public class LoginController : ControllerBase
    {
        DataBaseHandler dataBaseHandler = new DataBaseHandler();
        // GET: api/<ValuesController>
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
        // POST api/<ValuesController>
        [HttpPost]
        public bool loginValidation([FromBody] Athlete athlete)
        {
            Athlete athleteNew = new Athlete();
            try
            {
            NpgsqlDataReader reader = dataBaseHandler.getSingleRecord(DataBaseConstants.athlete,"username",athlete.username);
                while (reader.Read())
                {
                    athleteNew.username = (string)reader["username"];
                    athleteNew.password = (string)reader["password"];
                    /*athleteNew.name = (string)reader["name"];
                    athleteNew.nationality = (string)reader["nationality"];
                    athleteNew.birth_date = (DateTime)reader["birth_date"];
                    athleteNew.photo = (string)reader["photo"];
                    athleteNew.age = (int)reader["age"];*/
                }
            }
            catch
            {

            }
            //dataBaseHandler.getAthlete(athlete.username);
            if ((athlete.password).Equals(athleteNew.password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
