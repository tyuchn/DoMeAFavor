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
            Assert.AreEqual(3, missions.Count);
            Assert.AreEqual("food", missions[0].MissionName);
            Assert.AreEqual("mac", missions[1].Message);
        }

        [TestMethod]
        public async Task TestUpdateAsync()
        {
            var missionService = new MissionService();
            var missions = (await missionService.ListAsync()).ToList();
            var firstMission = missions[0];

            Assert.AreEqual("food", firstMission.MissionName);

            firstMission.MissionName = "cloth";
            await missionService.UpdateAsync(firstMission);

            missions = (await missionService.ListAsync()).ToList();
            firstMission = missions[0];

            Assert.AreEqual("cloth", firstMission.MissionName);
        }

        [TestMethod]
        public async Task TestAddAsync()
        {
            var missionService = new MissionService();

            var ms = new Mission();
            ms.Type = Mission.MissionType.Delivery;
            ms.CreationDate = DateTime.Today;
            ms.Deadline = DateTime.Today;
            ms.Message = "ddd";
            ms.Points = 3;
            ms.MissionName = "lunch";
            await missionService.AddAsync(ms);
            var missions = (await missionService.ListAsync()).ToList();

            Assert.AreEqual(4, missions.Count);
            //Assert.AreEqual("express", missions[0].MissionName);
            //Assert.AreEqual("lunch", missions[1].MissionName);
        }

        [TestMethod]
        public async Task TestDeleteAsync()
        {
            var missionService = new MissionService();
            var missions = (await missionService.ListAsync()).ToList();
            var secondMission = missions[1];
            await missionService.DeleteAsync(secondMission);
            var newMissions = (await missionService.ListAsync()).ToList();
            Assert.AreEqual(1, newMissions.Count);
        }
    }
}
