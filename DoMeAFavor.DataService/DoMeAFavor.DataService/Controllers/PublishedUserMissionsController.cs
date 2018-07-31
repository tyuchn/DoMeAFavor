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
    [Route("api/PublishedUserMissions")]
    public class UserMissions1Controller : Controller
    {
        private readonly DataContext _context;

        public UserMissions1Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserMission(string missionname,string message,int points)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userMission = from a in _context.Missions
                from b in _context.UserMissions
                
                where a.MissionId == b.MissionId  && a.MissionName == missionname && a.Message == message  && a.Points == points && b.ReceiverId == 0
                select b;

            return Ok(userMission);
        }
    }
}