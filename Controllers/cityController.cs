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
    public class cityController : ControllerBase
    {
        private readonly travelAndBookingContext _db;
        public cityController(travelAndBookingContext context)
        {
            _db = context;
        }


        // GET: api/<cityController>
        /* [HttpGet]
         public IEnumerable<string> Get()
         {
             return new string[] { "value1", "value2" };
         }*/

        // GET api/<cityController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var from_db = _db.Citys.FirstOrDefault(db => db.Id == id);
            if (from_db == null)
            {
                return BadRequest();
            }
            return Ok(from_db);
        }
    }
}
