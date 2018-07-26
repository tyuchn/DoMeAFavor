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