
using DoMeAFavor.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoMeAFavor.UnitTest.ViewModels
{
    [TestClass]
    public class SignupPageViewModelTest
    {
        [TestMethod]
        public void TestSignupCommand()
        {
            var newUser = new User
            {
                UserId = "20167878",
                UserName = "姚明",
                Major = "自动化专业",
                Class = "1612",
                RealName = "姚达明",
                PassWord = "123456",
                PhoneNumber = "17898789878"               
            };

        }
    }
}
