using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMeAFavor.Models;
using DoMeAFavor.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.AreEqual(1, missions.Count);
            Assert.AreEqual("express", missions[0].MissionName);
            Assert.AreEqual("kfc", missions[0].Message);
            Assert.AreEqual(new DateTime(2018, 7, 21), missions[0].Date);
        }

        [TestMethod]
        public async Task TestUpdateAsync()
        {
            var missionService = new MissionService();
            var missions = (await missionService.ListAsync()).ToList();
            var firstMission = missions[0];

            Assert.AreEqual("express", firstMission.MissionName);

            firstMission.MissionName = "ccc";
            await missionService.UpdateAsync(firstMission);

            missions = (await missionService.ListAsync()).ToList();
            firstMission = missions[0];

            Assert.AreEqual("ccc", firstMission.MissionName);

        }

        [TestMethod]
        public async Task TestAddAsync()
        {
            var missionService = new MissionService();
            
            var ms = new Mission();
            ms.MissionId = 10;
            ms.Date = DateTime.Today;
            ms.Deadline = DateTime.Today;
            ms.Message = "ddd";
            ms.Points = 3;
            ms.PublisherId = 20154464;
            ms.MissionName = "lunch";
            var qq = new Mission();
            qq.MissionName = "made";
            await missionService.AddAsync(ms);
            await missionService.AddAsync(qq);

            var missions = (await missionService.ListAsync()).ToList();

            Assert.AreEqual(3, missions.Count);
            //Assert.AreEqual("express", missions[0].MissionName);
            //Assert.AreEqual("lunch", missions[1].MissionName);

        }

        [TestMethod]
        public async Task TestDeleteAsync()
        {
            var missionService = new MissionService();
            var missions = (await missionService.ListAsync()).ToList();
            var secondMission = missions[2];
            await missionService.DeleteAsync(secondMission);
            Assert.AreEqual(2,missions.Count);
        }
        
    }
}
