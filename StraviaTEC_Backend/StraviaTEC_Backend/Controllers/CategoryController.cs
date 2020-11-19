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
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        DataBaseHandler dataBaseHandler = new DataBaseHandler();
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> getCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                NpgsqlDataReader reader = dataBaseHandler.readFromDataBase(DataBaseConstants.category, "*");
                while (reader.Read())
                {
                    categories.Add(new Category
                    {
                        race_id = (string)reader["race_id"],
                        category_name = (string)reader["category_name"],
                        description = (string)reader["description"]
                    });
                }
            }
            catch { }
            return categories;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{category_name}")]
        public Category getCategory(string category_name)
        {
            Category category = new Category();
            try
            {
                NpgsqlDataReader reader = dataBaseHandler.getSingleRecord(DataBaseConstants.category, "category_name", category_name);
                while (reader.Read())
                {

                    category.race_id = (string)reader["race_id"];
                    category.category_name = (string)reader["category_name"];
                    category.description = (string)reader["description"];

                }
            }
            catch { }
            return category;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.category_name == null)
                {
                    return BadRequest();
                }
                if (category.race_id == null)
                {
                    return BadRequest();
                }
                if (category.description == null)
                {
                    return BadRequest();
                }
                try
                {
                    dataBaseHandler.insertDataBase(DataBaseConstants.category,
                        "category_name, race_id, description",
                        category.category_name + "','" +
                        category.race_id + "','" +
                        category.description);
                    return Ok();
                }
                catch { }
            }
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{category_name}")]
        public IActionResult Put(string category_name, [FromBody] Category category)
        {
            try
            {
                string attribsToModify = "category_name = '" + category.category_name;
                if (category_name.Equals(category.category_name))
                {
                    if (category.race_id != null)
                    {
                        if (!((category.race_id).Equals("")))
                        {
                            attribsToModify = attribsToModify + ", race_id = '" + category.race_id;
                        }
                    }
                    if (category.description != null)
                    {
                        if (!((category.description).Equals("")))
                        {
                            attribsToModify = attribsToModify + ", description = '" + category.description;
                        }
                    }
                    dataBaseHandler.updateDataBase(DataBaseConstants.team, attribsToModify, "category_name = '" + category.category_name + "'");
                    return Ok();
                }
            }
            catch { }
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{category_name}")]
        public IActionResult Delete(string category_name)
        {
            if(dataBaseHandler.deleteFromDataBase(DataBaseConstants.category, "category_name = '" + category_name + "'"))
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
