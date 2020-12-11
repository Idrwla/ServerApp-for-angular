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
    public class TicketController : ControllerBase
    {
        private readonly travelAndBookingContext _db;

        public TicketController(travelAndBookingContext context)
        {
            _db = context;
        }

        // GET: api/<TicketController>
        [HttpGet]
        public IEnumerable<Ticket> Get() =>_db.Tickets.ToList<Ticket>();
        

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var from_db = _db.Tickets.FirstOrDefault(db => db.Id==id);
            if(from_db == null)
            {
                return BadRequest();
            }
            return Ok(from_db);
        }

        // POST api/<TicketController>
        [HttpPost]
        public IActionResult Post([FromBody] Ticket value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            value.Id = _db.Tickets.ToList().Count;
            _db.Tickets.Add(value);
            _db.SaveChanges();
            return Ok();
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Ticket value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            if (id != value.Id)
            {
                return BadRequest();
            }
            var from_db = _db.Tickets.FirstOrDefault(db => db.Id == id);
            if (from_db == null)
            {
                return BadRequest();
            }
            from_db = value;
            _db.SaveChanges();
            return Ok();
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var from_db = _db.Tickets.FirstOrDefault(db => db.Id == id);
            if (from_db == null)
            {
                return BadRequest();
            }
            _db.Remove(from_db);
            _db.SaveChanges();
            return Ok();
        }
    }
}
