using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace DoMeAFavor.Models
{
    /// <summary>
    /// 任务类
    /// </summary>
    public class Mission : ObservableObject
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int MissionId { get; set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        private string _missionName;

        /// <summary>
        /// 任务名称
        /// </summary>
        public string MissionName
        {
            get => _missionName;
            set => Set(nameof(MissionName), ref _missionName, value);
        }

        /// <summary>
        /// 任务说明
        /// </summary>
        private string _message;

        /// <summary>
        /// 任务说明
        /// </summary>
        public string Message
        {
            get => _message;
            set => Set(nameof(Message), ref _message, value);
        }

        /// <summary>
        /// 创建日期
        /// </summary>
        private DateTime _creationDate;
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreationDate
        {
            get => _creationDate;
            set => Set(nameof(CreationDate), ref _creationDate, value);
        }

        /// <summary>
        /// 截止日期
        /// </summary>
        private DateTime _deadline;
        /// <summary>
        /// 截止日期
        /// </summary>
        public DateTime Deadline
        {
            get => _deadline;
            set => Set(nameof(Deadline), ref _deadline, value);
        }
        /// <summary>
        /// 任务类型
        /// </summary>
        public MissionType Type { get; set; }
        /// <summary>
        /// 任务类型
        /// </summary>
        public enum MissionType
        {
            TakeOver,
            Delivery,
            Express,
        };

        private IList<UserMission> UserMissions { get; set; }



        /// <summary>
        /// 积分数。
        /// </summary>
        public int Points { get; set; }
    }
}
