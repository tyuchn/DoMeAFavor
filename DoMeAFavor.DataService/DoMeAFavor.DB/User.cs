using System;
using System.Collections.Generic;
using System.Text;

namespace DoMeAFavor.DB
{
    /// <summary>
    /// 用户类。
    /// </summary>
    public class User
    {
        /// <summary>
        /// 主键（学号）。
        /// </summary>
        //[JsonProperty("userid")]
        public int UserId { get; set; }

        /// <summary>
        /// 用户名。
        /// </summary>
        //[JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// 密码。
        /// </summary>
        //[JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// 真实姓名。
        /// </summary>
        //[JsonProperty("realname")]
        public string RealName { get; set; }

        /// <summary>
        /// 手机号。
        /// </summary>
        //[JsonProperty("phonenumber")]
        public int PhoneNumber { get; set; }

        /// <summary>
        /// 专业。
        /// </summary>
        //[JsonProperty("major")]
        public string Major { get; set; }

        /// <summary>
        /// 班级。
        /// </summary>
        //[JsonProperty("class")]
        public int Class { get; set; }

        /// <summary>
        /// 积分。
        /// </summary>
        //[JsonProperty("points")]
        public int Points { get; set; }

        /// <summary>
        /// 头像。
        /// </summary>
        //[JsonProperty("avatar")]
        public string Avatar { get; set; }



    }
}
