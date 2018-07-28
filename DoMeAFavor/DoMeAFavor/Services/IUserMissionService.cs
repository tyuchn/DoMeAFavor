using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoMeAFavor.Models;

namespace DoMeAFavor.Services
{
    public interface IUserMissionService
    {
        /// <summary>
        /// 接收任务（更改UserMission表）
        /// </summary>
        /// <param name="mission"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task AcceptAsync(Mission mission,User user);
        /// <summary>
        /// 发布任务（添加UserMission表）
        /// </summary>
        /// <param name="mission"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task PublishAsync(Mission mission,User user);
    }
}
