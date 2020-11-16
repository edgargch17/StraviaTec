using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StraviaTEC_Backend.Models;
using StraviaTEC_Backend.Controllers;
using Microsoft.AspNetCore.Http;
using StraviaTEC_Backend.DataBaseAccess;
//using Npgsql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaTEC.Controllers
{
    //[Produces ("application/json")]
    [Route("api/athlete")]
    //[ApiController]
    public class AthleteController : ControllerBase
    {
        //private readonly DataBaseHandler dataBaseHandler;
        DataBaseHandler dataBaseHandler = new DataBaseHandler();

        // GET: api/<DeportistaController>
        [HttpGet]
        public IEnumerable<Athlete> Get()
        //public void getAthletes()
        {

            //return dataBaseHandler.readFromDataBase(DataBaseConstants.athlete, "*");
            return dataBaseHandler.readFromDataBase(DataBaseConstants.athlete, "*");
        }

        // GET api/<DeportistaController>/5
        [HttpGet("{id}")]
        public string getAthlete(int id)
        {
            return "value";
        }

        // POST api/<DeportistaController>
        //[Route ("post")]
        [HttpPost]
        public IActionResult postAthlete([FromBody] Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                athlete.setAge();
                dataBaseHandler.insertDataBase(DataBaseConstants.athlete, 
                    "username, password, name, last_name, nationality, birth_date, photo, age", 
                    athlete.username + "','" + 
                    athlete.password + "','" +
                    athlete.name + "','" +
                    athlete.last_name + "','" +
                    athlete.nationality + "','" +
                    athlete.birth_date + "','" +
                    athlete.photo + "','" +
                    athlete.getAge());
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<DeportistaController>/5
        [HttpPut("{username}")]
        public void putAthlete(string username, [FromBody] Athlete athlete)
        {
            /*var model = athlete.username + "','" +
                    athlete.password + "','" +
                    athlete.name + "','" +
                    athlete.last_name + "','" +
                    athlete.nationality + "','" +
                    athlete.birth_date + "','" +
                    athlete.photo + "','" +
                    athlete.getAge();*/
            dataBaseHandler.updateDataBase(DataBaseConstants.athlete,
                "username, password, name, last_name, nationality, birth_date, photo, age",
                athlete.username + "','" +
                athlete.password + "','" +
                athlete.name + "','" +
                athlete.last_name + "','" +
                athlete.nationality + "','" +
                athlete.birth_date + "','" +
                athlete.photo + "'," +
                athlete.getAge()," username = '" + username +"'");
        }

        // DELETE api/<DeportistaController>/5
        [HttpDelete("{username}")]
        public void deleteAthlete(string username)
        {
            dataBaseHandler.deleteFromDataBase(DataBaseConstants.athlete, "username = '" + username + "'");
        }
    }
}
