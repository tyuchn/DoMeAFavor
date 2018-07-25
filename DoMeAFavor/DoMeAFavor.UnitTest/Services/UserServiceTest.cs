using System.Linq;
using System.Threading.Tasks;
using DoMeAFavor.Models;
using DoMeAFavor.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoMeAFavor.UnitTest.Services
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public async Task TestListAsync()
        {
            var userService = new UserService();

            var  users = (await userService.ListAsync()).ToList();
            //Assert.AreEqual(3, users.Count);
            //Assert.AreEqual("food", users[0].UserName);
            //Assert.AreEqual("mac", users[1].PassWord);
        }

        [TestMethod]
        public async Task TestUpdateAsync()
        {
            var userService = new UserService();
            var users = (await userService.ListAsync()).ToList();
            var firstMission = users[0];

            /* Assert.AreEqual("food", firstMission.MissionName);

             firstMission.MissionName = "cloth";
             await missionService.UpdateAsync(firstMission);

             missions = (await missionService.ListAsync()).ToList();
             firstMission = missions[0];

             Assert.AreEqual("cloth", firstMission.MissionName);*/
        }

        [TestMethod]
        public async Task TestAddAsync()
        {
            var userService = new UserService();

            var newUser = new User();
            newUser.UserName = "Jason";
            await userService.AddAsync(newUser);
            var users = (await userService.ListAsync()).ToList();

            Assert.AreEqual(2, users.Count);
            //Assert.AreEqual("express", missions[0].MissionName);
            //Assert.AreEqual("lunch", missions[1].MissionName);
        }

        [TestMethod]
        public async Task TestDeleteAsync()
        {
            var userService = new UserService();
            var users = (await userService.ListAsync()).ToList();
            var secondUser = users[1];
            await userService.DeleteAsync(secondUser);
            var newUsers = (await userService.ListAsync()).ToList();
            Assert.AreEqual(1, newUsers.Count);
        }
    }
}