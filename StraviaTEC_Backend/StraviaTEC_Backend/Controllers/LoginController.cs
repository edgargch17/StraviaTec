using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StraviaTEC_Backend.DataBaseAccess;
using StraviaTEC_Backend.Models;
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
            //dataBaseHandler.getAthlete(athlete.username);
            if ((athlete.password).Equals((dataBaseHandler.getAthlete(athlete.username)).password))
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
