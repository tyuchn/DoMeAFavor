
using System.Collections.Generic;

using System.Threading.Tasks;
using DoMeAFavor.Models;

namespace DoMeAFavor.Services
{
    public interface IUserService
    {
        
        User GetCurrentUser();
        /// <summary>
        /// 更新用户信息。
        /// </summary>
        /// <param name="user">要更新的用户。</param>
        Task UpdateAsync(User user); //更新到数据库中

        /// <summary>
        /// 添加用户。
        /// </summary>
        /// <returns></returns>
        Task AddAsync(User user);
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task <User> LoginAsync(string userid, string password);
        /// <summary>
        /// 查看所有用户
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<User>> ListAsync();
        /// <summary>
        /// 查看接收的任务
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<IEnumerable<Mission>> GetAcceptedMissionsAsync(string userid, string password);
        /// <summary>
        /// 查看发布的任务
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<IEnumerable<Mission>> GetPublishedMissionsAsync(string userid, string password);
    }

}
