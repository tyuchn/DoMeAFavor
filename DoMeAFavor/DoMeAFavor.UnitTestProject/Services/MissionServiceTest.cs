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
            Assert.AreEqual(new DateTime(2018, 7, 21), missions[0].CreationDate);
        }

        [TestMethod]
        public async Task TestUpdateAsync()
        {
            var missionService = new MissionService();
            var missions = (await missionService.ListAsync()).ToList();
            var firstMission = missions[0];

            Assert.AreEqual("delivery", firstMission.MissionName);

            firstMission.MissionName = "express";
            await missionService.UpdateAsync(firstMission);

            missions = (await missionService.ListAsync()).ToList();
            firstMission = missions[0];

            Assert.AreEqual("express", firstMission.MissionName);

        }

        [TestMethod]
        public async Task TestAddAsync()
        {
            var missionService = new MissionService();
            
            var ms = new Mission();
            ms.MissionName = "lunch";
            await missionService.AddAsync(ms);
            var missions = (await missionService.ListAsync()).ToList();

            Assert.AreEqual(2, missions.Count);
            Assert.AreEqual("express", missions[0].MissionName);
            Assert.AreEqual("lunch", missions[1].MissionName);

        }

        [TestMethod]
        public async Task DeleteAsync()
        {
            var missionService = new MissionService();
            var missions = (await missionService.ListAsync()).ToList();
            var secondMission = missions[1];
            await missionService.DeleteAsync(secondMission);
            Assert.AreNotEqual(1,missions.Count);
        }
        
    }
}
