using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly travelAndBookingContext _db;
        public UserController(travelAndBookingContext context)
        {
            _db = context;
        }

        // GET: api/<UserController>
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var from_db = _db.Users.FirstOrDefault(db => db.Id == id);
            if (from_db == null)
            {
                return BadRequest("User doesnot exist");
            }
            return Ok(from_db);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            if(value == null)
            {
                return BadRequest();
            }
            _db.Users.Add(value);
            _db.SaveChanges();
            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            if(id != value.Id)
            {
                return BadRequest();
            }
            var from_db = _db.Users.FirstOrDefault(db=>db.Id==id);
            if (from_db == null)
            {
                return BadRequest();
            }
            from_db = value;
            _db.SaveChanges();
            return Ok();

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var from_db = _db.Users.FirstOrDefault(db => db.Id == id);
            var isPartner = _db.Partners.FirstOrDefault(db => db.UserId == id);
            
            if (from_db == null)
            {
                return BadRequest();
            }

            if (isPartner != null)
            {   var haveMoney = _db.Banks.FirstOrDefault(db => db.Id == isPartner.BankId);
                if (haveMoney!=null && haveMoney.Karta != 0)
                {
                    return BadRequest("You can not delete your Accout cause your have a money");
                }
                _db.Partners.Remove(isPartner);
            }
            _db.Remove(from_db);
            _db.SaveChanges();
            return Ok();
        }
    }
}
