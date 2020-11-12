using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StraviaTEC_Backend.Models;
using Microsoft.AspNetCore.Http;
//using Npgsql;
//using System.Web.Http.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaTEC.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods:"*")]
    //[DisableCors]
    //[Produces ("application/json")]
    [Route("api/main")]
    //[ApiController]
    public class AthleteController : ControllerBase
    {
        //String postgresStr = "Server = localhost; User Id = postgres; Password = 2659; Database = postgres";
        //NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 2659; Database = StraviaTEC");
        
        
        
        ///<input>Data that must change in DB</input>
        ///<summary>This function open comunication between DB and rest service and let's edit DB information</summary>
        /*public void Connection()
        {
            conn.Open();
            
            //Here must edit postgres db 
            conn.Close();


        }

        public DataTable Consult()
        {
            string query = "SELECT * FROM \"Deportista\"";
            NpgsqlCommand connector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter data = new NpgsqlDataAdapter(connector);
            DataTable table = new DataTable();
            data.Fill(table);
            Console.WriteLine(table);
            return table;
        }*/

        // GET: api/<DeportistaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DeportistaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DeportistaController>
        [HttpPost]
        [Route ("post")]
        //public void postDeportista([FromBody] Deportista value)
        //public IActionResult postDeportista([FromBody] Deportista value)
        public IActionResult postDeportista([FromBody] Athlete value)
        {
            if (ModelState.IsValid)
            {
                var model = value;
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            //Console.WriteLine(model.username);
            //return Ok();

            //return JsonResult(new { success = true, result = "My name is" });
        }

        // PUT api/<DeportistaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DeportistaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
