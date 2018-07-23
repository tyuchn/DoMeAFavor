using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoMeAFavor.DataService.Models
{
    /// <summary>
    /// 完成的任务类。
    /// </summary>
    public class UserMission
    {
        /// <summary>
        /// 主键（学号）。
        /// </summary>
        ///[JsonProperty("userid")]
        public int UserId { get; set; }

        /// <summary>
        /// 主键（编号）。
        /// </summary>
        ///[JsonProperty("missionid")]
        public int MissioinId { get; set; }

        /// <summary>
        /// 完成时间。
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        /// 评价。
        /// </summary>
        [JsonProperty("misssion")]
        public Mission Mission { get; set; }

    }
}
