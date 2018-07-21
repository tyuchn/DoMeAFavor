using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace DoMeAFavor.Models
{
    public class CompletedMission : ObservableObject
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
        ///[JsonProperty("completetime")]
        public DateTime CompleteTime { get; set; }

        public string _evaluation;

        /// <summary>
        /// 评价。
        /// </summary>
        ///[JsonProperty("evaluation")]
        public string Evaluation
        {
            get => _evaluation;
            set => Set(nameof(Evaluation), ref _evaluation, value);
        }
    }
}
