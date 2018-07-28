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
            Assert.AreEqual(8, missions.Count);
            //Assert.AreEqual("food", missions[0].MissionName);
            //Assert.AreEqual("mac", missions[1].Message);
        }


        [TestMethod]
        public async Task TestAddMissionAsync()
        {
            var missionService = new MissionService();
            var mission = new Mission
            {
                MissionName = "测试",
                Type = 0
            };
            var user = new User
            {
                UserId = "1"
                
            };
            await missionService.AddAsync(mission, user);
            var newmission = (await missionService.ListAsync()).ToList().Last();
            Assert.AreEqual("测试",newmission.MissionName);


        }

        [TestMethod]
        public async Task TestDeleteAsync()
        {
            var missionService = new MissionService();
            var missions = (await missionService.ListAsync()).ToList();
            var secondMission = missions[1];
            await missionService.DeleteAsync(secondMission);
            var newMissions = (await missionService.ListAsync()).ToList();
            Assert.AreEqual(8, newMissions.Count);
        }
    }
}
