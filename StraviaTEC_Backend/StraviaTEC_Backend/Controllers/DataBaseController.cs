using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaTEC_Backend.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class DataBaseController : ControllerBase
    {
        /**<summary>COMANDOS PARA ACCCEDER A LAS TABLAS</summary>*/
        public string athlete_command = "deportista";
        public string race_command = "carrera";


        /**<summary>COMANDOS DE CONTROL PARA LA BASE DE DATOS</summary>*/
        public string select_command = "SELECT";
        public string from_command = "FROM";




    }
}
/*  // GET: api/<DataBaseController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DataBaseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DataBaseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DataBaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DataBaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
*/