using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoMeAFavor.DataService.Models
{
    /// <summary>
    /// 任务类。
    /// </summary>
    public class Mission
    {
        /// <summary>
        /// 主键（编号）。
        /// </summary>
        ///[JsonProperty("missionid")]
        public int MissionId { get; set; }

        /// <summary>
        /// 类型。
        /// </summary>
        ///[JsonProperty("missionname")]
        public string MissionName { get; set; }

        /// <summary>
        /// 发布时间。
        /// </summary>
        ///[JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// 截止时间。
        /// </summary>
        ///[JsonProperty("deadline")]
        public DateTime Deadline { get; set; }

        /// <summary>
        /// 内容。
        /// </summary>
        ///[JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 发布人Id。
        /// </summary>
        ///[JsonProperty("publisherid")]
        public int PublisherId { get; set; }

        /// <summary>
        /// 积分数。
        /// </summary>
        ///[JsonProperty("points")]
        public int Points { get; set; }

    }
}
