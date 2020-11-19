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
    [Route("api/team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        DataBaseHandler dataBaseHandler = new DataBaseHandler();
        // GET: api/<TeamController>
        [HttpGet]
        public IEnumerable<Team> getTeams()
        {
            List<Team> teams = new List<Team>();
            try
            {
                NpgsqlDataReader reader = dataBaseHandler.readFromDataBase(DataBaseConstants.team, "*");
                while (reader.Read())
                {
                    teams.Add( new Team
                    {
                        name = (string)reader["name"],
                        administrator = (string)reader["administrator"],
                        team_identifier = (string)reader["team_identifier"]
                    });
                }
            }
            catch { }

            return teams;
        }

        // GET api/<TeamController>/5
        [HttpGet("{team_identifier}")]
        public Team getTeam(string team_identifier)
        {
            Team team = new Team();
            try
            {
                NpgsqlDataReader reader = dataBaseHandler.getSingleRecord(DataBaseConstants.team, "team_identifier", team_identifier);
                while (reader.Read())
                {
                    team.name = (string)reader["name"];
                    team.administrator = (string)reader["administrator"];
                    team.team_identifier = (string)reader["team_identifier"];
                }
            }
            catch { }

            return team;
        }

        // POST api/<TeamController>
        [HttpPost]
        public IActionResult postTeam([FromBody] Team team)
        {
            if (ModelState.IsValid)
            {
                if (team.team_identifier == null)
                {
                    return BadRequest();
                }
                if (team.name == null)
                {
                    return BadRequest();
                }
                if (team.administrator == null)
                {
                    return BadRequest();
                }
                try
                {
                    dataBaseHandler.insertDataBase(DataBaseConstants.team,
                        "name, administrator, team_identifier",
                        team.name + "','" +
                        team.administrator + "','" +
                        team.team_identifier);
                    return Ok();
                }
                catch { }
            }
            return BadRequest();
        }

        // PUT api/<TeamController>/5
        [HttpPut("{team_identifier}")]
        public IActionResult putTeam(string team_identifier, [FromBody] Team team)
        {
            try
            {
                string attribsToModify = "team_identifier = '" + team.team_identifier;
                if (team_identifier.Equals(team.team_identifier))
                {
                    if(team.name != null)
                    {
                        if (! ( (team.name).Equals("") ))
                        {
                            attribsToModify = attribsToModify + ", name = '" + team.name;
                        }
                    }
                    if (team.administrator != null)
                    {
                        if (! ( (team.administrator).Equals("") ))
                        {
                            attribsToModify = attribsToModify + ", administrator = '" + team.administrator;
                        }
                    }
                    dataBaseHandler.updateDataBase(DataBaseConstants.team, attribsToModify, "team_identifier = '" + team.team_identifier + "'");
                    return Ok();
                }
            }
            catch { }
            return BadRequest();
        }

        // DELETE api/<TeamController>/5
        [HttpDelete("{team_identifier}")]
        public IActionResult deleteTeam(string team_identifier)
        {
            if (dataBaseHandler.deleteFromDataBase(DataBaseConstants.team, "team_identifier = '" + team_identifier + "'"))
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
