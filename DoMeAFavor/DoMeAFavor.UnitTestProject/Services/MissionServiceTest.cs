using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMeAFavor.Models;
using DoMeAFavor.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoMeAFavor.UnitTestProject.Services
{
    [TestClass]
    public class MissionServiceTest
    {
        [TestMethod]
        public async Task TestListAsync()
        {
            var missionService = new MissionService();

            var missions = (await missionService.ListAsync()).ToArray();
            Assert.AreEqual(missions.Length, 3);
            var firstMission = missions[0];
            Assert.AreEqual("Delivery", firstMission.MissionName);
            Assert.AreEqual("KFC", firstMission.Message);
            //Assert.AreEqual(new DateTime(1984, 1, 5), firstMission.Date);
        }
        [TestMethod]
        public async Task UpdateAsync()
        {
            var missionService = new MissionService();

            var firstMission = (await missionService.ListAsync()).First();
            Assert.AreEqual(firstMission.MissionName, "Delivery");

            firstMission.MissionName = "giao";
            await missionService.UpdateAsync(firstMission);
            Assert.AreEqual(
                (await missionService.ListAsync()).First().MissionName, "giao");
        }
        [TestMethod]
        public async Task AddAsync()
        {
            var missionService = new MissionService();
            var ms = new Mission();
            ms.Message = "111";
            await missionService.AddAsync(ms);
            
            Assert.AreEqual(
                (await missionService.ListAsync()).Last().Message, "111");
        }
        [TestMethod]
        public async Task DeleteAsync()
        {
            var missionService = new MissionService();
            var firstMission = (await missionService.ListAsync()).First();
            await missionService.DeleteAsync(firstMission);
            Assert.AreNotEqual("KFC",(await missionService.ListAsync()).First());
        }

    }
}
