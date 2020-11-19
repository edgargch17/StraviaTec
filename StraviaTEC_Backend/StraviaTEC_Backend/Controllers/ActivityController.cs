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
    [Route("api/activity")]
    //[ApiController]
    public class ActivityController : ControllerBase
    {
        DataBaseHandler dataBaseHandler = new DataBaseHandler();
        
        // GET: api/<ActivityController>
        [HttpGet]
        public IEnumerable<Activity> getActivities()
        {
            List<Activity> activities = new List<Activity>();
            try
            {
                NpgsqlDataReader reader = dataBaseHandler.readFromDataBase(DataBaseConstants.activity, "*");
                while (reader.Read())
                {
                    activities.Add(
                        new Activity()
                        {
                            category = (string)reader["category"],
                            type_act = (string)reader["type_act"],
                            duration = (TimeSpan)reader["duration"],
                            distancia = (int)reader["distancia"],
                            date_time = (DateTime)reader["date_time"],
                            map = (string)reader["map"],
                            challenge_race = (string)reader["challenge_race"],
                            activity_identifier = (string)reader["activity_identifier"]
                        });
                }
            }
            catch
            {

            }
            return activities;
        }

        // GET api/<ActivityController>/5
        [HttpGet("{id}")]
        public Activity getActivity(string id)
        {
            Activity activity = new Activity();
            try
            {
                NpgsqlDataReader reader = dataBaseHandler.getSingleRecord(DataBaseConstants.activity, "activity_identifier ", id);
                while (reader.Read())
                {
                    activity.category = (string)reader["category"];
                    activity.type_act = (string)reader["type_act"];
                    activity.duration = (TimeSpan)reader["duration"];
                    activity.distancia = (int)reader["distancia"];
                    activity.date_time = (DateTime)reader["date_time"];
                    activity.map = (string)reader["map"];
                    activity.challenge_race = (string)reader["challenge_race"];
                    activity.activity_identifier = (string)reader["activity_identifier"];
                }
            }
            catch
            {

            }
            return activity;
        }

        // POST api/<ActivityController>
        [HttpPost]
        public IActionResult postActivity([FromBody] Activity activity)
        {
            if (ModelState.IsValid)
            {
                if (activity.activity_identifier == null)
                {
                    return BadRequest();
                }
                if (activity.type_act == null)
                {
                    return BadRequest();
                }
                if (activity.date_time == DateTime.MinValue)
                {
                    return BadRequest();
                }
                dataBaseHandler.insertDataBase(DataBaseConstants.activity,
                    "category, type_act, duration, date_time, map, challenge_race, activity_identifier, distancia",
                    activity.category + "','" +
                    activity.type_act + "','" +
                    activity.duration + "','" +
                    activity.date_time + "','" +
                    activity.map + "','" +
                    activity.challenge_race + "','" +
                    activity.activity_identifier + "', " +
                    activity.distancia);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<ActivityController>/5
        [HttpPut("{id}")]
        public IActionResult putActivity(string id, [FromBody] Activity activity)
        {
            string attribstoModify = "activity_identifier = '" + activity.activity_identifier;
            if (id.Equals(activity.activity_identifier))
            {
                if (activity.category != null)
                {
                    if (!((activity.category).Equals("")))
                    {
                        attribstoModify = attribstoModify + "', category  = '" + activity.category;
                    }
                }
                if (activity.type_act != null)
                {
                    if (!((activity.type_act).Equals("")))
                    {
                        attribstoModify = attribstoModify + "', type_act  = '" + activity.type_act;
                    }
                }
                if (activity.duration != null)
                {
                    if (!((activity.duration).Equals("")))
                    {
                        attribstoModify = attribstoModify + "', duration  = '" + activity.duration;
                    }
                }
                if (activity.date_time != DateTime.MinValue)
                {
                    attribstoModify = attribstoModify + "', date_time  = '" + activity.date_time;
                }
                if (activity.map != null)
                {
                    if (!((activity.map).Equals("")))
                    {
                        attribstoModify = attribstoModify + "', map  = '" + activity.map;
                    }
                }
                if (activity.challenge_race != null)
                {
                    if (!((activity.challenge_race).Equals("")))
                    {
                        attribstoModify = attribstoModify + "', challenge_race  = '" + activity.challenge_race + "'";
                    }
                }
                if (activity.distancia != 0)
                {
                    attribstoModify = attribstoModify + ", distancia  = " + activity.distancia;
                }
            }
            try
            {
                if(dataBaseHandler.updateDataBase(DataBaseConstants.activity, attribstoModify, "activity_identifier = '" + activity.activity_identifier + "'"))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<ActivityController>/5
        [HttpDelete("{activity_identifier}")]
        public IActionResult deleteActivity(string activity_identifier)
        {
            if (dataBaseHandler.deleteFromDataBase(DataBaseConstants.activity, "activity_identifier = '" + activity_identifier + "'"))
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
