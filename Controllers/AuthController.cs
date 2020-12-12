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
    public class AuthController : ControllerBase
    {
        private readonly travelAndBookingContext _db;
        public AuthController(travelAndBookingContext context)
        {
            _db = context;
        }
        // GET: api/<AuthController>
        [HttpPost]
        public IActionResult PostSingIn( string email, string pass)
        {
            if (email == null || pass == null)
            {
                return BadRequest("probles is here");
            }

            var from_db = _db.Users.FirstOrDefault(db => db.Email == email && db.Password == pass);
            if (from_db == null)
            {
                return BadRequest(" User not found");
            }

            return Ok(from_db);
        }
    }
}
