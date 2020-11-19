using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StraviaTEC_Backend.Models;
using StraviaTEC_Backend.DataBaseAccess;
using Npgsql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaTEC_Backend.Controllers
{
    [Route("api/race")]
    //[ApiController]
    public class RaceController : ControllerBase
    {
        DataBaseHandler dataBaseHandler = new DataBaseHandler();

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Race> getRaceList()
        {
            List<Race> race_list = new List<Race>();
            try
            {
                NpgsqlDataReader reader = dataBaseHandler.readFromDataBase(DataBaseConstants.race, "*");
                 while (reader.Read())
                {
                    race_list.Add( new Race()
                    {
                        race_name = (string)reader["race_name"],
                        travel = (string)reader["travel"],
                        race_date = (DateTime)reader["race_date"],
                        money_cost = (int)reader["money_cost"],
                        activity_type = (string)reader["activity_type"],
                        race_identifier = (string)reader["race_identifier"],
                        activity_id = (string)reader["activity_id"]
                    });
                }
            }
            catch { }

            return race_list;
            
        }

        // GET api/<CategoryController>/5
        [HttpGet("{race_identifier}")]
        public Race getRace(string race_identifier)
        {
            Race race = new Race();
            try
            {
                NpgsqlDataReader reader = dataBaseHandler.getSingleRecord(DataBaseConstants.race, "race_identifier", race_identifier);
                while (reader.Read())
                {
                    race.race_name = (string)reader["race_name"];
                    race.travel = (string)reader["travel"];
                    race.race_date = (DateTime)reader["race_date"];
                    race.money_cost = (int)reader["money_cost"];
                    race.activity_type = (string)reader["activity_type"];
                    race.race_identifier = (string)reader["race_identifier"];
                    race.activity_id = (string)reader["activity_id"];
                }
            }
            catch { }

            return race;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult postRace([FromBody] Race race)
        {
            if (ModelState.IsValid)
            {
                if (race.race_identifier == null)
                {
                    return BadRequest();
                }
                if (race.money_cost == 0)
                {
                    return BadRequest();
                }
                if (race.race_name == null)
                {
                    return BadRequest();
                }
                try
                {
                    dataBaseHandler.insertDataBase(DataBaseConstants.race,
                        "race_name, travel, race_date, money_cost, activity_type, race_identifier, activity_id",
                        race.race_name + "','" +
                        race.travel + "','" +
                        race.race_date + "','" +
                        race.activity_type + "','" +
                        race.race_identifier + "','" +
                        race.activity_id + "','" +
                        race.money_cost);
                    return Ok();
                }
                catch { }
            }
            return BadRequest();
             
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{race_identifier}")]
        public IActionResult putRace(string race_identifier, [FromBody] Race race)
        {
            try
            {
                string attribsToModify = "race_identifier = '" + race.race_identifier;
                if (race_identifier.Equals(race.race_identifier))
                {
                    if (race.race_name != null)
                    {
                        if (!((race.race_name).Equals(""))){
                            attribsToModify = attribsToModify + "race_name = '" + race.race_name;
                        }
                    }
                    if (race.travel != null)
                    {
                        if (!((race.travel).Equals("")))
                        {
                            attribsToModify = attribsToModify + " travel = '" + race.travel;
                        }
                    }
                    if (race.race_date != DateTime.MinValue)
                    {
                        attribsToModify = attribsToModify + " race_date = '" + race.race_date;
                    }
                    if (race.activity_type != null)
                    {
                        if (!((race.activity_type).Equals(""))){
                            attribsToModify = attribsToModify + " activity_type = '" + race.activity_type;
                        }
                    }
                    if (race.activity_id != null)
                    {
                        if (!((race.activity_id).Equals("")))
                        {
                            attribsToModify = attribsToModify + " activity_id = '" + race.activity_id;
                        }
                    }
                    attribsToModify = attribsToModify + " money_cost = " + race.money_cost;
                    dataBaseHandler.updateDataBase(DataBaseConstants.race, attribsToModify, "race_identifier = '" + race.race_identifier + "'");
                    return Ok();
                }
            }
            catch { }
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{race_identifier}")]
        public IActionResult deleteRace(string race_identifier)
        {
            if (dataBaseHandler.deleteFromDataBase(DataBaseConstants.race, "race_identifier = '" + race_identifier + "'"))
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
