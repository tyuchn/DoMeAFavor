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
    ///     任务服务。
    /// </summary>
    public class UserService : IUserService
    {
        /******** 私有变量 ********/

        /// <summary>
        ///     服务端点。
        /// </summary>
        private const string ServiceEndpoint =
            "http://localhost:13059/api/Users";
        private const string LoginServiceEndpoint =
            "http://localhost:13059/api/Login";
        private const string AcceptedMissionsServiceEndpoint =
            "http://localhost:13059/api/AcceptedMissions";
        private const string PublishedMissionsServiceEndpoint =
            "http://localhost:13059/api/PublishedMissions";


        /******** 公开属性 ********/

        /******** 继承方法 ********/
        /// <summary>
        /// 列出所有任务。
        /// </summary>
        /// <returns>所有任务。</returns>
        public async Task<IEnumerable<User>> ListAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(ServiceEndpoint);
                return JsonConvert.DeserializeObject<User[]>(json);
            }
        }
        public async Task<IEnumerable<Mission>> GetAcceptedMissionsAsync(string userid, string password)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(AcceptedMissionsServiceEndpoint + "?userid=" + userid + "&password=" + password);
                return JsonConvert.DeserializeObject<Mission[]>(json);
            }
        }
        public async Task<IEnumerable<Mission>> GetPublishedMissionsAsync(string userid, string password)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(PublishedMissionsServiceEndpoint + "?userid=" + userid + "&password=" + password);
                return JsonConvert.DeserializeObject<Mission[]>(json);
            }
        }
        /// <summary>
        /// 登陆.
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns>用户信息</returns>
        public async Task<User> LoginAsync(string userid,string password)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(LoginServiceEndpoint + "?userid=" + userid + "&password=" + password);
                return JsonConvert.DeserializeObject<User>(json);
            }
        }

        /// <summary>
        /// 删除用户。
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task DeleteAsync(User user)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(user);
                await client.DeleteAsync(ServiceEndpoint + "/" + user.Id);
            }
        }

        

        /// <summary>
        ///     更新用户。
        /// </summary>
        /// <param name="user">要更新的用户。</param>
        public async Task UpdateAsync(User user)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(user);
                await client.PutAsync(ServiceEndpoint + "/" + user.Id,
                    new StringContent(json, Encoding.UTF8,
                        "application/json"));
            }
        }

        /// <summary>
        ///     添加用户。
        /// </summary>
        public async Task AddAsync(User user)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(user);
                await client.PostAsync(ServiceEndpoint,
                    new StringContent(json, Encoding.UTF8, "application/json"));
            }
        }


        /******** 公开方法 ********/

        /******** 私有方法 ********/
    }
}