using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoMeAFavor.DataService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoMeAFavor.DataService.Controllers
{
    [Produces("application/json")]
    [Route("api/Missions")]
    public class MissionsController : Controller
    {
        private readonly DataContext _context;

        public MissionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Missions
        [HttpGet]
        public IEnumerable<Mission> GetMissions()
        {
            return _context.Missions;
        }

        // GET: api/Missions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMission([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var mission = await _context.Missions.SingleOrDefaultAsync(m => m.MissionId == id);

            if (mission == null) return NotFound();

            return Ok(mission);
        }

        // PUT: api/Missions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMission([FromRoute] int id, [FromBody] Mission mission)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != mission.MissionId) return BadRequest();

            _context.Entry(mission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // POST: api/Missions
        [HttpPost]
        public async Task<IActionResult> PostMission([FromBody] Mission mission)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Missions.Add(mission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMission", new {id = mission.MissionId}, mission);
        }

        // DELETE: api/Missions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMission([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var mission = await _context.Missions.SingleOrDefaultAsync(m => m.MissionId == id);
            if (mission == null) return NotFound();

            _context.Missions.Remove(mission);
            await _context.SaveChangesAsync();

            return Ok(mission);
        }

        private bool MissionExists(int id)
        {
            return _context.Missions.Any(e => e.MissionId == id);
        }
    }
}