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
    [Route("api/challenge")]
    //[ApiController]
    public class ChallengeController : ControllerBase
    {
        DataBaseHandler dataBaseHandler = new DataBaseHandler();
        // GET: api/<ChallengeController>
        [HttpGet]
        public IEnumerable<Challenge> getChallenges()
        {
            List<Challenge> challenges = new List<Challenge>();
            try
            {
                NpgsqlDataReader reader = dataBaseHandler.readFromDataBase(DataBaseConstants.challenge, "*");
                while (reader.Read())
                {
                    challenges.Add(new Challenge()
                    {
                        description = (string)reader["description"],
                        name_challenge = (string)reader["name_challenge"],
                        start_date = (DateTime)reader["start_date"],
                        end_date = (DateTime)reader["end_date"],
                        type_challenge = (string)reader["type_challenge"],
                        activity_id = (string)reader["activity_id"],
                        challenge_identifier = (string)reader["challenge_identifier"]
                    });
                }
            }
            catch { }
            return challenges;
        }

        // GET api/<ChallengeController>/5
        [HttpGet("{challenge_identifier}")]
        public Challenge getChallenge(string challenge_identifier)
        {
            Challenge challenge = new Challenge();
            try
            {
                NpgsqlDataReader reader = dataBaseHandler.getSingleRecord(DataBaseConstants.challenge, "challenge_identifier", challenge_identifier);
                while (reader.Read())
                {

                    challenge.description = (string)reader["description"];
                    challenge.name_challenge = (string)reader["name_challenge"];
                    challenge.start_date = (DateTime)reader["start_date"];
                    challenge.end_date = (DateTime)reader["end_date"];
                    challenge.type_challenge = (string)reader["type_challenge"];
                    challenge.activity_id = (string)reader["activity_id"];
                    challenge.challenge_identifier = (string)reader["challenge_identifier"];
                    
                }
            }
            catch { }
            return challenge;
        }

        // POST api/<ChallengeController>
        [HttpPost]
        public IActionResult Post([FromBody] Challenge challenge)
        {
            if (ModelState.IsValid)
            {
                if (challenge.challenge_identifier == null)
                {
                    return BadRequest();
                }
                if (challenge.name_challenge == null)
                {
                    return BadRequest();
                }
                if ((challenge.start_date != DateTime.MinValue) && (challenge.start_date < challenge.end_date))
                {
                    return BadRequest();
                }
                try
                {
                    dataBaseHandler.insertDataBase(DataBaseConstants.challenge,
                        "description, name_challenge, start_date, end_date, type_challenge, activity_id, challenge_identifier",
                        challenge.description + "','" +
                        challenge.name_challenge + "','" +
                        challenge.start_date + "','" +
                        challenge.end_date + "','" +
                        challenge.type_challenge + "','" +
                        challenge.activity_id + "','" +
                        challenge.challenge_identifier + "'");
                    return Ok();
                }
                catch { }

            }
            return BadRequest();
        }

        // PUT api/<ChallengeController>/5
        [HttpPut("{challenge_identifier}")]
        public IActionResult Put(string challenge_identifier, [FromBody] Challenge challenge)
        {
            try
            {
                string attribsToModify = "challenge_identifier = '" + challenge.challenge_identifier + "'";
                if ((challenge_identifier).Equals(challenge.challenge_identifier))
                {
                    if (challenge.description != null)
                    {
                        if (!((challenge.description).Equals("")))
                        {
                            attribsToModify = attribsToModify + ", description = '" + challenge.description + "'";
                        }
                    }
                    if (challenge.name_challenge != null)
                    {
                        if (! ( (challenge.name_challenge).Equals("") ))
                        {
                            attribsToModify = attribsToModify + ", name_challenge = '" + challenge.name_challenge + "'";
                        }
                    }
                    if ((challenge.start_date != DateTime.MinValue) && (challenge.start_date < challenge.end_date))
                    {
                        attribsToModify = attribsToModify + ", start_date = '" + challenge.start_date + "'";
                        attribsToModify = attribsToModify + ", end_date = '" + challenge.end_date + "'";
                    }
                    if (challenge.type_challenge != null)
                    {
                        if(! ( (challenge.type_challenge).Equals("") ))
                        {
                            attribsToModify = attribsToModify + ", type_challenge = '" + challenge.type_challenge + "'";
                        }
                    }
                    if (challenge.activity_id != null)
                    {
                        if ( !( (challenge.activity_id).Equals("") ))
                        {
                            attribsToModify = attribsToModify + ", activity_id = '" + challenge.activity_id + "'";
                        }
                    }
                    dataBaseHandler.updateDataBase(DataBaseConstants.challenge, attribsToModify, "challenge_identifier = '" + challenge.challenge_identifier + "'");
                    return Ok();
                }   
            }
            catch { }
            return BadRequest();
        }

        // DELETE api/<ChallengeController>/5
        [HttpDelete("{challenge_identifier}")]
        public IActionResult Delete(string challenge_identifier)
        {
            if (dataBaseHandler.deleteFromDataBase(DataBaseConstants.challenge, "challenge_identifier = '" + challenge_identifier + "'"))
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
