
using System.Collections.Generic;
using System.Linq;
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
            "http://172.20.10.4:13059/api/Missions";
        private const string UMServiceEndpoint =
            "http://172.20.10.4:13059/api/UserMissions";
        private const string PBUMServiceEndpoint =
            "http://172.20.10.4:13059/api/PublishedUserMissions?";

        private const string MissionServiceEndpoint = "http://172.20.10.4:13059/api/GetMissionsFromName";
        private const string UnacceptedServiceEndpoint = "http://172.20.10.4:13059/api/UnacceptedMissions";





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
        /// 列出所有未被接受的任务
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Mission>> ListUnacceptedAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(UnacceptedServiceEndpoint);
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
                
                var json = await client.GetStringAsync(PBUMServiceEndpoint + "missionname=" + mission.MissionName);
                var usermisson = JsonConvert.DeserializeObject<UserMission[]>(json);
                usermisson.First().ReceiverId = user.Id;
                var newjson = JsonConvert.SerializeObject(usermisson.First());
                await client.PutAsync(UMServiceEndpoint + "/" + usermisson.First().MissionId,                   
                    new StringContent(newjson, Encoding.UTF8, "application/json"));
                
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
                await client.PostAsync(ServiceEndpoint,
                    new StringContent(json, Encoding.UTF8, "application/json"));
                var latestCreatedMissionJson =
                    await client.GetStringAsync(MissionServiceEndpoint+"?missionname=" +
                                                mission.MissionName);
                var latestCreatedMission = JsonConvert.DeserializeObject<Mission[]>(latestCreatedMissionJson);
                mission.MissionId = latestCreatedMission.Last().MissionId;

                var usermission = new UserMission
                {
                    UserId = user.Id,
                    MissionId = mission.MissionId

                };
                var umjson = JsonConvert.SerializeObject(usermission);
                 

                await client.PostAsync(UMServiceEndpoint,
                    new StringContent(umjson, Encoding.UTF8, "application/json"));


            }
        }

        /*public async Task addum(UserMission usermission)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(usermission);
                await client.PostAsync(UMServiceEndpoint,
                    new StringContent(json, Encoding.UTF8, "application/json"));
            }
        }*/



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
