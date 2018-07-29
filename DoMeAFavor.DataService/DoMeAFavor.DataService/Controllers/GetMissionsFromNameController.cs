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
    [Route("api/GetMissionsFromName")]
    public class GetMissionsFromNameController : Controller
    {
        private readonly DataContext _context;

        public GetMissionsFromNameController(DataContext context)
        {
            _context = context;
        }

        

        // GET: api/GetMissionsFromName/5
        [HttpGet]
        public async Task<IActionResult> GetMission(string missionname)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var missions = from a in _context.Missions where a.MissionName == missionname select a;
            //var mission = await _context.Missions.SingleOrDefaultAsync(m => m.MissionName == missionname);

            

            return Ok(missions);
        }

        
    }
}