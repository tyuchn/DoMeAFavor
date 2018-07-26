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
            Assert.AreEqual(17, users.Count);
            //Assert.AreEqual("food", users[0].UserName);
            //Assert.AreEqual("mac", users[1].PassWord);
        }
        [TestMethod]
        public async Task TestLoginAsync()
        {
            var userService = new UserService();
            var user = await userService.LoginAsync("20151111", "000000");
            Assert.AreEqual("1504",user.Class);
        }
        [TestMethod]
        public async Task TestACMAsync()
        {
            var userService = new UserService();
            var missions = await userService.GetAcceptedMissionsAsync("20151111", "000000");
            Assert.AreEqual(5, missions.First().MissionId);
        }
        [TestMethod]
        public async Task TestPBMAsync()
        {
            var userService = new UserService();
            var missions = await userService.GetPublishedMissionsAsync("20150000", "000000");
            Assert.AreEqual(8, missions.Last().MissionId);
        }
        [TestMethod]
        public async Task TestUpdateAsync()
        {
            var userService = new UserService();
            var users = (await userService.ListAsync()).ToList();
            var firstUser = users[0];

             Assert.AreEqual("20158888", firstUser.UserId);

             firstUser.UserId = "20157777";
             await userService.UpdateAsync(firstUser);

             users = (await userService.ListAsync()).ToList();
             firstUser = users[0];

             Assert.AreEqual("20157777", firstUser.UserId);
        }

        [TestMethod]
        public async Task TestAddAsync()
        {
            var userService = new UserService();

            var newUser = new User
            {
                UserName = "Jason"
            };
            await userService.AddAsync(newUser);
            var users = (await userService.ListAsync()).ToList();

            Assert.AreEqual(18, users.Count);
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
            Assert.AreEqual(17, newUsers.Count);
        }
    }
}