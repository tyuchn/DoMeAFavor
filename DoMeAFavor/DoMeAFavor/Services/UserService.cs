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
            "http://localhost:13059/api/Users";

        /******** 公开属性 ********/

        /******** 继承方法 ********/

        /// <summary>
        /// 列出所有用户。
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

        public async  Task<string> LoginAsync(User user)
        {
            string valid = "";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(ServiceEndpoint);
                var allUsers = JsonConvert.DeserializeObject<User[]>(json);
                var selectedUser = allUsers.Where(c => c.UserId == user.UserId).ToArray();
                var loginUser = selectedUser.First();
                if (loginUser == null)
                {
                    valid = "用户不存在";
                }
                else
                {
                    if (user.PassWord == loginUser.PassWord)
                    {
                        valid = "登陆成功";
                    }
                    else
                    {
                        valid = "密码错误";
                    }
                }
                return valid;
            }
        }

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
                        "application/json")); 
            }
        }

        /// <summary>
        /// 添加用户。
        /// </summary>
        public async Task AddAsync(User user)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(user);
                await client.PostAsync(ServiceEndpoint ,
                    new StringContent(json, Encoding.UTF8, "application/json"));
            }
        }

        

        /******** 公开方法 ********/

        /******** 私有方法 ********/
    }
}
