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
    public class TypesController : ControllerBase
    {
        private readonly travelAndBookingContext _db;
        public TypesController(travelAndBookingContext context)
        {
            _db = context;
        }

        // GET api/<TypesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var from_db = _db.Types.FirstOrDefault(db => db.Id == id);
            if (from_db == null)
            {
                return BadRequest();
            }
            return Ok(from_db);
        }
    }
}
