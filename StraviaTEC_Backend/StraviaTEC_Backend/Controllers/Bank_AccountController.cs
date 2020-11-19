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
    /// <summary>
    /// REVISAR COMILLAS E IMPUTS DE METODOS
    /// </summary>
    [Route("api/bank_account")]
    //[ApiController]
    public class Bank_AccountController : ControllerBase
    {
        DataBaseHandler dataBaseHandler = new DataBaseHandler();
        // GET: api/<Bank_AccountController>
        [HttpGet]
        public IEnumerable<Bank_Account> getBank_Accounts()
        {
            List<Bank_Account> bank_Accounts = new List<Bank_Account>();
            try
            {
                NpgsqlDataReader reader = dataBaseHandler.readFromDataBase(DataBaseConstants.bank_account, "*");
                while (reader.Read())
                {
                    bank_Accounts.Add(new Bank_Account
                    {
                        race_id = (string)reader["race_id"],
                        owner_id = (string)reader["owner_id"],
                        number_account = (string)reader["number_account"]
                    });
                }
            }
            catch { }

            return bank_Accounts;
        }

        // GET api/<Bank_AccountController>/5
        [HttpGet("{number_account}")]
        public Bank_Account getBank_Account(string number_account)
        {
            Bank_Account bank_Account = new Bank_Account();
            try
            {
                NpgsqlDataReader reader = dataBaseHandler.getSingleRecord(DataBaseConstants.bank_account, "number_account", number_account);
                while (reader.Read())
                {
                    bank_Account.race_id = (string)reader["race_id"];
                    bank_Account.owner_id = (string)reader["owner_id"];
                    bank_Account.number_account = (string)reader["number_account"];
                }

            }
            catch { }

            return bank_Account;
        }

        // POST api/<Bank_AccountController>
        [HttpPost]
        public IActionResult Post([FromBody] Bank_Account bank_Account)
        {
            if (ModelState.IsValid)
            {
                if (bank_Account.race_id == null)
                {
                    return BadRequest();
                }
                if (bank_Account.owner_id == null)
                {
                    return BadRequest();
                }
                if (bank_Account.race_id == null)
                {
                    return BadRequest();
                }
                try
                {
                    dataBaseHandler.insertDataBase(DataBaseConstants.bank_account,
                        "number_account, owner_id, race_id",
                        bank_Account.number_account + "','" +
                        bank_Account.owner_id + "','" +
                        bank_Account.race_id + "'");
                    return Ok();
                }
                catch { }
            }
            return BadRequest();
        }

        // PUT api/<Bank_AccountController>/5
        [HttpPut("{number_account}")]
        public IActionResult Put(string number_account, [FromBody] Bank_Account bank_Account)
        {
            try
            {
                string attribsToModify = "number_account = '" + bank_Account.number_account;
                if (number_account.Equals(bank_Account.number_account))
                {
                    if (bank_Account.owner_id != null)
                    {
                        if (!((bank_Account.owner_id).Equals("")))
                        {
                            attribsToModify = attribsToModify + "', owner_id = '" + bank_Account.owner_id;
                        }
                    }
                    if (bank_Account.race_id != null)
                    {
                        if (!((bank_Account.race_id).Equals("")))
                        {
                            attribsToModify = attribsToModify + "', race_id = '" + bank_Account.race_id;
                        }
                    }
                    dataBaseHandler.updateDataBase(DataBaseConstants.bank_account, attribsToModify + "'", "number_account = '" + bank_Account.number_account + "'");
                    return Ok();
                }
            }
            catch { }
            return BadRequest();
        }

        // DELETE api/<Bank_AccountController>/5
        [HttpDelete("{number_account}")]
        public IActionResult Delete(string number_account)
        {
            if (dataBaseHandler.deleteFromDataBase(DataBaseConstants.bank_account, "number_account = '" + number_account + "'"))
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
