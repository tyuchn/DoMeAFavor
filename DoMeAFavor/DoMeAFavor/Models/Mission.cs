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
    public class Mission:ObservableObject
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int MissionId;
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
        /// 日期
        /// </summary>
        private DateTime _date;
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date
        {
            get => _date;
            set => Set(nameof(Date), ref _date, value);
        }
    }
}
