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
    [Route("api/sponsor")]
    [ApiController]
    public class SponsorController : ControllerBase
    {
        DataBaseHandler dataBaseHandler = new DataBaseHandler();

        // GET: api/<SponsorController>
        [HttpGet]
        public IEnumerable<Sponsor> Get()
        {
            List<Sponsor> sponsors = new List<Sponsor>();
            try
            {
                NpgsqlDataReader reader = dataBaseHandler.readFromDataBase(DataBaseConstants.sponsor, "*");
                while (reader.Read())
                {
                    sponsors.Add(new Sponsor()
                    {
                        legal_represent = (string)reader["legal_represent"],
                        logo = (string)reader["logo"],
                        phone = (string)reader["phone"],
                        tradename = (string)reader["tradename"]
                    });
                }
            } catch { }
            return sponsors;
        }

        // GET api/<SponsorController>/5
        [HttpGet("{tradename}")]
        public Sponsor Get(string tradename)
        {
            Sponsor sponsor = new Sponsor();
            try
            {
                NpgsqlDataReader reader = dataBaseHandler.getSingleRecord(DataBaseConstants.sponsor, "tradename", tradename);
                while (reader.Read())
                {
                    sponsor.legal_represent = (string)reader["legal_represent"];
                    sponsor.logo = (string)reader["logo"];
                    sponsor.phone = (string)reader["phone"];
                    sponsor.tradename = (string)reader["tradename"];
                }
            }
            catch { }
            return sponsor;
        }

        // POST api/<SponsorController>
        [HttpPost]
        public IActionResult Post([FromBody] Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                if (sponsor.tradename == null)
                {
                    return BadRequest();
                }
                if (sponsor.legal_represent == null)
                {
                    return BadRequest();
                }
                try
                {
                    dataBaseHandler.insertDataBase(DataBaseConstants.sponsor,
                        "legal_represent, logo, phone, tradename",
                        sponsor.legal_represent + "','" +
                        sponsor.logo + "','" +
                        sponsor.phone + "','" +
                        sponsor.tradename + "'");
                    return Ok();
                }
                catch { }
            }
            return BadRequest();
        }

        // PUT api/<SponsorController>/5
        [HttpPut("{tradename}")]
        public IActionResult Put(string tradename, [FromBody] Sponsor sponsor)
        {
            try
            {
                string attribsToModify = "tradename = '" + sponsor.tradename;
                if (tradename.Equals(sponsor.tradename))
                {
                    if (sponsor.legal_represent != null)
                    {
                        if (! ((sponsor.legal_represent).Equals("") ))
                        {
                            attribsToModify = attribsToModify + ", legal_represent = '" + sponsor.legal_represent;
                        }
                    }
                    if (sponsor.logo != null)
                    {
                        if (!((sponsor.logo).Equals("")))
                        {
                            attribsToModify = attribsToModify + ", logo = '" + sponsor.logo;
                        }
                    }
                    if (sponsor.phone != null)
                    {
                        if (! ( (sponsor.phone).Equals("") ))
                        {
                            attribsToModify = attribsToModify + ", phone = '" + sponsor.phone + "'";
                        }
                    }
                }
                dataBaseHandler.updateDataBase(DataBaseConstants.sponsor, attribsToModify, "tradename = '" + sponsor.tradename + "'");
                return Ok();
            }
            catch { }
            return BadRequest();
        }

        // DELETE api/<SponsorController>/5
        [HttpDelete("{tradename}")]
        public IActionResult Delete(string tradename)
        {
            if (dataBaseHandler.deleteFromDataBase(DataBaseConstants.sponsor, tradename))
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
