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
            "http://172.20.10.5:13059/api/Users";
        private const string LoginServiceEndpoint =
            "http://172.20.10.5:13059/api/Login";
        private const string AcceptedMissionsServiceEndpoint =
            "http://172.20.10.5:13059/api/AcceptedMissions";
        private const string PublishedMissionsServiceEndpoint =
            "http://172.20.10.5:13059/api/PublishedMissions";

        
        /******** 公开属性 ********/
        private User LoginUser;
        

        /******** 继承方法 ********/
        /// <summary>
        /// 所有用户信息
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> ListAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(ServiceEndpoint);
                return JsonConvert.DeserializeObject<User[]>(json);
            }
        }
        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns></returns>
        public User GetCurrentUser()
        {
            return LoginUser;
        }

        /// <summary>
        /// 获取接受的任务
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Mission>> GetAcceptedMissionsAsync(string userid, string password)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(AcceptedMissionsServiceEndpoint + "?userid=" + userid + "&password=" + password);
                return JsonConvert.DeserializeObject<Mission[]>(json);
            }
        }
        /// <summary>
        /// 获取发布的任务
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Mission>> GetPublishedMissionsAsync(string userid, string password)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(PublishedMissionsServiceEndpoint + "?userid=" + userid + "&password=" + password);
                return JsonConvert.DeserializeObject<Mission[]>(json);
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns>用户信息</returns>
        public async Task<User> LoginAsync(string userid,string password)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(LoginServiceEndpoint + "?userid=" + userid + "&password=" + password);
                var loginUser = JsonConvert.DeserializeObject<User>(json);
                LoginUser = loginUser;
                return LoginUser;
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
        public async Task<bool> AddAsync(User user)
        {
            using (var client = new HttpClient())
            {
                var allusersjson = await client.GetStringAsync(ServiceEndpoint);
                var allusers = JsonConvert.DeserializeObject<User[]>(allusersjson);
                foreach (var auser in allusers)
                {
                    if (auser.UserId == user.UserId)
                    {
                        return false;
                    }
                }
                var json = JsonConvert.SerializeObject(user);
                await client.PostAsync(ServiceEndpoint,
                    new StringContent(json, Encoding.UTF8, "application/json"));
                return true;
            }
        }


        /******** 公开方法 ********/

        /******** 私有方法 ********/
    }
}