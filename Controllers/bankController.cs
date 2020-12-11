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
    public class bankController : ControllerBase
    {
        private readonly travelAndBookingContext _db;
        public bankController(travelAndBookingContext context)
        {
            _db = context;
        }
        
        // GET api/<bankController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var from_db = _db.Banks.FirstOrDefault(db => db.Id == id);
            if (from_db == null)
            {
                return BadRequest();
            }
            return Ok(from_db);
        }
    }
}
