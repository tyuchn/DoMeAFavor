using System;
using System.Collections.Generic;

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
        [JsonProperty("missionid")]
        public int MissionId { get; set; }

        /// <summary>
        /// 任务名称。
        /// </summary>
        [JsonProperty("missionname")]
        public string MissionName { get; set; }

        /// <summary>
        /// 发布时间。
        /// </summary>
        [JsonProperty("creationdate")]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// 截止时间。
        /// </summary>
        [JsonProperty("deadline")]
        public DateTime Deadline { get; set; }

        /// <summary>
        /// 内容。
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 任务类型。
        /// </summary>
        public enum MissionType
        {
            TakeOver,
            Delivery,
            Express
        }

        /// <summary>
        /// 任务类型。
        /// </summary>
        [JsonProperty("type")]
        public MissionType Type { get; set; }

        /// <summary>
        /// 积分数。
        /// </summary>
        [JsonProperty("points")]
        public int Points { get; set; }

        /// <summary>
        /// 用户任务表。
        /// </summary>
        public IList<UserMission> UserMissions { get; set; }

    }
}
