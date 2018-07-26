
using System.Collections.Generic;

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// 服务端点。
        /// </summary>
        private const string ServiceEndpoint =
            "http://192.168.3.228:13059/api/Missions";

        /*private List<Mission> missions = new List<Mission>
        {
            new Mission{MissionId = 1,MissionName = "Delivery", Message = "KFC",CreationDate = DateTime.Now},
            new Mission{MissionId = 2,MissionName = "TakeOverClass", Message = "Hurry", CreationDate = DateTime.Parse("2018-07-24 11:45")},
            new Mission{MissionId = 3,MissionName = "Homework", Message = "Math",CreationDate = DateTime.Now}
        };*/


        /******** 公开属性 ********/

        /******** 继承方法 ********/

        /// <summary>
        /// 列出所有任务。
        /// </summary>
        /// <returns>所有任务。</returns>
        public async Task<IEnumerable<Mission>> ListAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(ServiceEndpoint);
                return JsonConvert.DeserializeObject<Mission[]>(json);
            }
        }

        /// <summary>
        /// 更新任务。
        /// </summary>
        /// <param name="mission">要更新的任务。</param>
        public async Task UpdateAsync(Mission mission)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(mission);
                await client.PutAsync(ServiceEndpoint + "/" + mission.MissionId,
                    new StringContent(json, Encoding.UTF8, "application/json"));
            }
        }

        /// <summary>
        /// 添加任务。
        /// </summary>
        public async Task AddAsync(Mission mission)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(mission);
                 await client.PostAsync(ServiceEndpoint,
                    new StringContent(json, Encoding.UTF8, "application/json"));                
            }
        }



        /// <summary>
        /// 删除任务。
        /// </summary>
        /// <param name="mission"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Mission mission)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(mission);
                await client.DeleteAsync(ServiceEndpoint + "/" + mission.MissionId);
            }
        }




        /******** 公开方法 ********/

        /******** 私有方法 ********/
    }
}
