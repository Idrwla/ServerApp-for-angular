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
    public class PartnerController : ControllerBase
    {
        private readonly travelAndBookingContext _db;
        public PartnerController(travelAndBookingContext context)
        {
            _db = context;
        }

        // GET api/<PartnerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var from_db = _db.Partners.FirstOrDefault(db => db.UserId == id);
            if (from_db == null)
            {
                return BadRequest("User doesnot exist");
            }
            return Ok(from_db);
        }

        // POST api/<PartnerController>
        [HttpPost]
        public IActionResult Post([FromBody] Partner value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            value.Id = _db.Partners.ToList().Count;
            _db.Partners.Add(value);
            _db.SaveChanges();
            return Ok();
        }

        // PUT api/<PartnerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Partner value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            if (id != value.Id)
            {
                return BadRequest();
            }
            var from_db = _db.Partners.FirstOrDefault(db => db.Id == id);
            if (from_db == null)
            {
                return BadRequest();
            }
            from_db = value;
            _db.SaveChanges();
            return Ok();

        }
    }
}
