using System;
using System.Collections.Generic;
using System.Text;

namespace DoMeAFavor.DB
{
    /// <summary>
    /// 完成的任务类。
    /// </summary>
    public class CompletedMission
    {

        public int Id { get; set; }

        /// <summary>
        /// 学号。
        /// </summary>
        //[JsonProperty("userid")]
        public int UserId { get; set; }

        public User User { get; set; }

        public int MissionId { get; set; }

        public Mission Mission { get; set; } 

    }
}
