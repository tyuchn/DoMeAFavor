using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DoMeAFavor.Models;


namespace DoMeAFavor.Services
{
    /// <summary>
    /// 任务服务。
    /// </summary>
    public class UserService : IUserService
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
        /// 更新用户。
        /// </summary>
        /// <param name="user">要更新的用户。</param>
        public async Task UpdateAsync(User user)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(user);
                await client.PutAsync(ServiceEndpoint + "/" + user.UserId,
                    new StringContent(json, Encoding.UTF8,
                        "application/json")); // 如为 new StringContent(json) 则不工作。
            }
        }

        /******** 公开方法 ********/

        /******** 私有方法 ********/
    }
}
