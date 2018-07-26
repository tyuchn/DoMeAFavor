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
    [Route("api/PublishedMissions")]
    public class PublishedMissionsController : Controller
    {
        private readonly DataContext _context;

        public PublishedMissionsController(DataContext context)
        {
            _context = context;
        }


        // GET: api/Users?userid= , password=
        [HttpGet]
        public async Task<IActionResult> GetUser(string userid, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.SingleOrDefaultAsync(m => m.UserId == userid && m.Password == password);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}