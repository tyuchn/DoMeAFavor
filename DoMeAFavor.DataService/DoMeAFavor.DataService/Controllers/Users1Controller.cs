using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoMeAFavor.DataService.Models;

namespace DoMeAFavor.DataService.Controllers
{
    [Produces("application/json")]
    [Route("api/Users1")]
    public class Users1Controller : Controller
    {
        private readonly DataContext _context;

        public Users1Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAUser(string userid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = from m in _context.Users where m.UserId.Equals(userid) select m;
            return Ok(user);
        }
    }
}