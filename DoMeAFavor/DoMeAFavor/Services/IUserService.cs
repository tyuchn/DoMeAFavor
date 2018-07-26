
using System.Collections.Generic;

using System.Threading.Tasks;
using DoMeAFavor.Models;

namespace DoMeAFavor.Services
{
    public  interface IUserService
    {

        /// <summary>
        /// 列出所有用户。
        /// </summary>
        /// <returns>所有任务。</returns>
        Task<IEnumerable<User>> ListAsync();

        /// <summary>
        /// 更新用户信息。
        /// </summary>
        /// <param name="user">要更新的用户。</param>
        Task UpdateAsync(User user);  //更新到数据库中
        
        /// <summary>
        /// 添加用户。
        /// </summary>
        /// <returns></returns>
        Task AddAsync(User user);

        Task<User> LoginAsync(string userid, string password);
    }
}
