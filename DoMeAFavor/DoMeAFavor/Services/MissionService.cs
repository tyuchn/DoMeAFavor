
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
            "http://172.20.10.5:13059/api/Missions";
        private const string UMServiceEndpoint =
            "http://172.20.10.5:13059/api/UserMissions";





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
        /// 接收任务
        /// </summary>
        /// <param name="mission"></param> 任务
        /// <param name="user"></param> 接收用户
        /// <returns></returns>
        public async Task AcceptAsync(Mission mission,User user)
        {
            using (var client = new HttpClient())
            {
                
                var json = await client.GetStringAsync(UMServiceEndpoint + "1?userid=" 
                    + user.UserId + "&missionname=" + mission.MissionName);
                var usermisson = JsonConvert.DeserializeObject<UserMission>(json);
                usermisson.ReceiverId = user.Id;
                await client.PutAsync(UMServiceEndpoint + "/" + usermisson.MissionId,                   //{问题：如何找到id}
                    new StringContent(json, Encoding.UTF8, "application/json"));
            }
        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="mission"></param> 任务
        /// <param name="user"></param> 发布人
        /// <returns></returns>
        public async Task AddAsync(Mission mission,User user)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(mission);
                var usermission = new UserMission
                {
                    UserId = user.Id,
                    MissionId = mission.MissionId

                };
                var umjson = JsonConvert.SerializeObject(usermission);
                 await client.PostAsync(ServiceEndpoint,
                    new StringContent(json, Encoding.UTF8, "application/json"));
                await client.PostAsync(UMServiceEndpoint,
                    new StringContent(umjson, Encoding.UTF8, "application/json"));


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
