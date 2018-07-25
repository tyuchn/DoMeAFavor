using Microsoft.VisualStudio.TestTools.UnitTesting;

using DoMeAFavor.Models;
using DoMeAFavor.ViewModels;

namespace DoMeAFavor.UnitTest.ViewModels
{
    [TestClass]
    public class HallPageViewModelTest
    {
        [TestMethod]
        public void TestListCommand()
        {
            var missions = new[]
            {
                new Mission {MissionId = 1, MissionName = "aaa"},
                new Mission {MissionId = 2, MissionName = "bbb"},
                new Mission {MissionId = 3, MissionName = "ccc"},
            };
            var stubIMissionService = new StubIMissionService().ListAsync(async () => missions);
            var viewModel = new HallPageViewModel(stubIMissionService);
            viewModel.ListCommand.Execute(null);
            Assert.AreEqual(missions.Length, viewModel.MissionCollection.Count);
            for (int i = 0; i < missions.Length; i++)
            {
                Assert.AreSame(missions[i], viewModel.MissionCollection[i]);
            }
        }

        [TestMethod]
        public void TestAddCommand()
        {
            Mission amission = null;
            var mission = new Mission { MissionName = "aaa", MissionId = 1 };
            var stubIMissionService = new StubIMissionService().AddAsync(async (c) => amission = c);

            var viewModel = new HallPageViewModel(stubIMissionService);


            viewModel.AddCommand.Execute(mission);

            Assert.AreSame(amission, mission);
        }
    }
}
