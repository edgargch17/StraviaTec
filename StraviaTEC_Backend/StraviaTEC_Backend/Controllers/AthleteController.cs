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
using System.Reflection;
//using Npgsql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaTEC.Controllers
{
    //[Produces ("application/json")]
    //[ApiController]
    [Route("api/athlete")]
    public class AthleteController : ControllerBase
    {
        //private readonly DataBaseHandler dataBaseHandler;
        DataBaseHandler dataBaseHandler = new DataBaseHandler();

        // GET: api/<DeportistaController>
        [HttpGet]
        public IEnumerable<Athlete> getAthletes()
        {
            return dataBaseHandler.readAthleteFromDataBase(DataBaseConstants.athlete, "*");
        }

        // GET api/<DeportistaController>/5
        [HttpGet("{username}")]
        public Athlete getAthlete(string username)
        {
            return dataBaseHandler.getAthlete(username);
        }

        // POST api/<DeportistaController>
        //[Route ("post")]
        [HttpPost]
        public IActionResult postAthlete([FromBody] Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                if (athlete.username == null)
                {
                    return BadRequest();
                }
                if (athlete.birth_date != DateTime.MinValue)
                {
                    athlete.setAge();
                }
                if (athlete.password == null)
                {
                    return BadRequest();
                }
                if (athlete.name == null)
                {
                    return BadRequest();
                }
                dataBaseHandler.insertDataBase(DataBaseConstants.athlete, 
                    "username, password, name, last_name, nationality, birth_date, photo, age", 
                    athlete.username + "','" + 
                    athlete.password + "','" +
                    athlete.name + "','" +
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
        public IActionResult putAthlete(string username, [FromBody] Athlete athlete)
        {
            try
            {
                string attribsToModify = "username = '" + athlete.username;
                if (username.Equals(athlete.username))
                {
                    if (athlete.password != null)
                    {
                        if (!((athlete.password).Equals("")))
                        {
                            attribsToModify = attribsToModify + "', password = '" + athlete.password;
                        }
                    }
                    if (athlete.name != null)
                    {
                        if (!((athlete.name).Equals("")))
                        {
                            attribsToModify = attribsToModify + "', name = '" + athlete.name;
                        }
                    }
                    if (athlete.nationality != null)
                    {
                        if (!((athlete.nationality).Equals("")))
                        {
                            attribsToModify = attribsToModify + "', nationality = '" + athlete.nationality;
                        }
                    }
                    if (athlete.photo != null)
                    {
                        if (!((athlete.photo).Equals("")))
                        {
                            attribsToModify = attribsToModify + "', photo = '" + athlete.photo;
                        }
                    }
                    if (athlete.birth_date != DateTime.MinValue)
                    {
                        athlete.setAge();
                        attribsToModify = attribsToModify + "', birth_date = '" + athlete.birth_date + "', age = " + athlete.getAge(); ;
                    }

                    dataBaseHandler.updateDataBase(DataBaseConstants.athlete, attribsToModify, "username = '" + athlete.username + "'");
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }catch (Exception e)
            {
                return BadRequest();
            }
        }

        // DELETE api/<DeportistaController>/5
        [HttpDelete("{username}")]
        public IActionResult deleteAthlete(string username)
        {
            if(dataBaseHandler.deleteFromDataBase(DataBaseConstants.athlete, "username = '" + username + "'"))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
