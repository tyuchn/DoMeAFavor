using System;
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
            "";

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
                var missions = JsonConvert.DeserializeObject<Mission[]>(json);
                return missions;
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
                    new StringContent(json, Encoding.UTF8,
                        "application/json")); // 如为 new StringContent(json) 则不工作。
            }
        }

        


        /******** 公开方法 ********/

        /******** 私有方法 ********/
    }
}
