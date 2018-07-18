using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMeAFavor.Models;

namespace DoMeAFavor.Services
{
    public  interface IUserService
    {
        /// <summary>
        /// 更新用户信息。
        /// </summary>
        /// <param name="user">要更新的用户。</param>
        Task UpdateAsync(User user);
        
        //添加用户
        //Task AddAsync();
    }
}
