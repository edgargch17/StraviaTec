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
using Npgsql;
using StraviaTEC_Backend.Tools;

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
            List<Athlete> athletes = new List<Athlete>();
            try
            {
                NpgsqlDataReader reader = dataBaseHandler.readFromDataBase(DataBaseConstants.athlete, "*");
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

        // GET api/<DeportistaController>/5
        [HttpGet("{username}")]
        public Athlete getAthlete(string username)
        {
            Athlete athlete = new Athlete();
            NpgsqlDataReader reader = dataBaseHandler.getSingleRecord(DataBaseConstants.athlete, "username", username);
            try
            {
                while (reader.Read())
                {
                    athlete.username = (string)reader["username"];
                    athlete.password = (string)reader["password"];
                    athlete.full_name = (string)reader["full_name"];
                    athlete.nationality = (string)reader["nationality"];
                    athlete.birth_date = (DateTime)reader["birth_date"];
                    athlete.photo = (string)reader["photo"];
                    athlete.age = (int)reader["age"];
                }
            }
            catch
            {

            }
            return athlete;
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
                if (athlete.full_name == null)
                {
                    return BadRequest();
                }
                dataBaseHandler.insertDataBase(DataBaseConstants.athlete,
                    "username, password, full_name, nationality, birth_date, photo, age",
                    athlete.username + "','" +
                    athlete.password + "','" +
                    athlete.full_name + "','" +
                    athlete.nationality + "','" +
                    athlete.birth_date + "','" +
                    athlete.photo + "'," +
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
                    if (athlete.full_name != null)
                    {
                        if (!((athlete.full_name).Equals("")))
                        {
                            attribsToModify = attribsToModify + "', full_name = '" + athlete.full_name;
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
            }
            catch //(Exception e)
            {
                return BadRequest();
            }
        }

        // DELETE api/<DeportistaController>/5
        [HttpDelete("{username}")]
        public IActionResult deleteAthlete(string username)
        {
            if (dataBaseHandler.deleteFromDataBase(DataBaseConstants.athlete, "username = '" + username + "'"))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        /////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////

        [HttpPost("{username}/uploadImage")]
        public IActionResult handleImage(string username, FileUPloadAPI image)//, [FromQuery] string token)
        {
            try
            {
                if (image.files.Length > 0)
                {
                    string savedLocation = FileManager.saveFile(image, username);

                    if (savedLocation == null)
                    {
                        return Forbid("File extension is not valid");
                    }

                    return Ok("Saved successfully");

                }

                return NotFound("No data to process");
            }
            catch (Exception ex)
            {

                return BadRequest("");
            }
        }

        /*[HttpGet("getProfilePicture")]
        public IActionResult getProfilePicture([FromQuery] string token)
        {

            try
            {
                return new FileStreamResult(FileManager.getUserPhoto(token), "application/octet-stream");
            }
            catch (Exception)
            {

                return NotFound("Image was not found");
            }
        }/**/
    }
}