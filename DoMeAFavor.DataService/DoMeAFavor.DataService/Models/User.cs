using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoMeAFavor.DataService.Models
{
    /// <summary>
    /// 用户类。
    /// </summary>
    public class User
    {

        /// <summary>
        /// 主键。
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// 学号。
        /// </summary>
        [JsonProperty("userid")]
        public string UserId { get; set; }

        /// <summary>
        /// 用户名。
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// 密码。
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// 真实姓名。
        /// </summary>
        [JsonProperty("realname")]
        public string RealName { get; set; }

        /// <summary>
        /// 手机号。
        /// </summary>
        [JsonProperty("phonenumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 专业。
        /// </summary>
        [JsonProperty("major")]
        public string Major { get; set; }

        /// <summary>
        /// 班级。
        /// </summary>
        [JsonProperty("class")]
        public string Class { get; set; }

        /// <summary>
        /// 积分。
        /// </summary>
        [JsonProperty("points")]
        public int Points { get; set; }

        /// <summary>
        /// 头像。
        /// </summary>
        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// 用户任务表。
        /// </summary>
        public IList<UserMission> UserMissions { get; set; }

    }
}
