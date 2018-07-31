using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using System.Linq;

using DoMeAFavor.Models;
using DoMeAFavor.Services;
using System.Threading.Tasks;

namespace DoMeAFavor.UnitTest.Services
{
    [TestClass]
    public class MissionServiceTest
    {
        [TestMethod]
        public async Task TestListAsync()
        {
            var missionService = new MissionService();

            var missions = (await missionService.ListAsync()).ToList();
            Assert.AreEqual(26, missions.Count);
            //Assert.AreEqual("food", missions[0].MissionName);
            //Assert.AreEqual("mac", missions[1].Message);
        }


        [TestMethod]
        public async Task TestAddMissionAsync()
        {
            var missionService = new MissionService();
            var mission = new Mission
            {
                MissionName = "高数代课"
                
            };
            var user = new User
            {
                Id =1
                
            };
            await missionService.AddAsync(mission, user);
            Assert.AreEqual(1, 1);


        }
        [TestMethod]
        public async Task TestAcceptMissionAsync()
        {
            var missionService = new MissionService();
            var mission = new Mission{MissionName = "1231"};
            var acceptuser = new User
            {
                Id = 1

            };

            await missionService.AcceptAsync(mission, acceptuser);
            Assert.AreEqual(1, 1);
        }


        public async Task TestDeleteAsync()
        {
            var missionService = new MissionService();
            var missions = (await missionService.ListAsync()).ToList();
            var secondMission = missions[25];
            await missionService.DeleteAsync(secondMission);
            var newMissions = (await missionService.ListAsync()).ToList();
            Assert.AreEqual(25, newMissions.Count);
        }
    }
}
