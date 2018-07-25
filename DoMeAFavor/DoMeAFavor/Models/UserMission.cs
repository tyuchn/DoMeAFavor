using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoMeAFavor.Models
{
    public class UserMission
    {
        /// <summary>
        /// 用户
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// 任务
        /// </summary>
        public int MissionId { get; set; }
        /// <summary>
        /// 任务
        /// </summary>
        public Mission Mission { get; set; }
        /// <summary>
        /// 接收者
        /// </summary>
        public int ReceiverId { get; set; }

    }
}
