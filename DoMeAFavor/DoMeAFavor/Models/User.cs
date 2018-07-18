using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  GalaSoft.MvvmLight;
namespace DoMeAFavor.Models
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class User:ObservableObject
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        private string _userName;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get => _userName;
            set => Set(nameof(UserName), ref _userName, value);
        }

        public string PassWord
        {
            get;
            set;
        }

        public string Avatar
        {
            get;
            set;
        }

        public DateTime BirthDay
        {
            get;
            set;
        }
    }
}
