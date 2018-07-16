using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoMeAFavor.DataService.Models
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class User
    {
        /// <summary>
        /// 学号。
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名。
        /// </summary>
        public String Username { get; set; }

        /// <summary>
        /// 密码。
        /// </summary>
        public String Password { get; set; }



    }
}
