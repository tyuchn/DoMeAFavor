using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using DoMeAFavor.Models;
using Newtonsoft.Json;

namespace DoMeAFavor.Services
{
    /// <summary>
    /// 任务服务。
    /// </summary>
    public class MissionService : IMissionService
    {
        /******** 私有变量 ********/

        private List<Mission> missions = new List<Mission>
        {
            new Mission{MissionId = 1,MissionName = "Delivery", Message = "KFC",Date = DateTime.Now},
            new Mission{MissionId = 2,MissionName = "TakeOverClass", Message = "Hurry", Date = DateTime.Parse("2018-07-24 11:45")},
            new Mission{MissionId = 3,MissionName = "Homework", Message = "Math",Date = DateTime.Now}
        };


        /******** 公开属性 ********/

        /******** 继承方法 ********/

        /// <summary>
        /// 列出所有任务。
        /// </summary>
        /// <returns>所有任务。</returns>
        public async Task<IEnumerable<Mission>> ListAsync()
        {
            var Missions = this.missions;
            return Missions;
        }

        /// <summary>
        /// 更新任务。
        /// </summary>
        /// <param name="mission">要更新的任务。</param>
        public async Task UpdateAsync(Mission mission)
        {
            missions.Add(mission);//redo
        }

        /// <summary>
        /// 增加任务
        /// </summary>
        /// <returns></returns>
        public async Task AddAsync(Mission mission)
        {
            
            missions.Add(mission);
        }




        public async Task DeleteAsync(Mission mission)
        {
            foreach (var Mission in missions)
            {
                if (Mission.MissionId.Equals(mission.MissionId))
                {
                    missions.Remove(Mission);
                    return;
                    
                }
            }
        }




        /******** 公开方法 ********/

        /******** 私有方法 ********/
    }
}
