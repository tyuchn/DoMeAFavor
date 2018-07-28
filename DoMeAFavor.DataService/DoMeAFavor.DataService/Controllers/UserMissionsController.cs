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
    [Route("api/UserMissions")]
    public class UserMissionsController : Controller
    {
        private readonly DataContext _context;

        public UserMissionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/UserMissions
        [HttpGet]
        public IEnumerable<UserMission> GetUserMissions()
        {
            return _context.UserMissions;
        }

        // GET: api/UserMissions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserMission([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userMission = await _context.UserMissions.SingleOrDefaultAsync(m => m.MissionId == id);

            if (userMission == null)
            {
                return NotFound();
            }

            return Ok(userMission);
        }

        // PUT: api/UserMissions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserMission([FromRoute] int id, [FromBody] UserMission userMission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userMission.MissionId)
            {
                return BadRequest();
            }

            _context.Entry(userMission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserMissionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserMissions
        [HttpPost]
        public async Task<IActionResult> PostUserMission([FromBody] UserMission userMission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserMissions.Add(userMission);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserMissionExists(userMission.MissionId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserMission", new { id = userMission.MissionId }, userMission);
        }

        // DELETE: api/UserMissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserMission([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userMission = await _context.UserMissions.SingleOrDefaultAsync(m => m.MissionId == id);
            if (userMission == null)
            {
                return NotFound();
            }

            _context.UserMissions.Remove(userMission);
            await _context.SaveChangesAsync();

            return Ok(userMission);
        }

        private bool UserMissionExists(int id)
        {
            return _context.UserMissions.Any(e => e.MissionId == id);
        }
    }
}