using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
namespace DoMeAFavor.Models
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class User: ObservableObject
    {
        /// <summary>
        /// 主键。
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        private int _userId;

        /// <summary>
        /// 学号
        /// </summary>
        public int UserId
        {
            get => _userId;
            set => Set(nameof(UserId), ref _userId, value);
        }
        
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

        /// <summary>
        /// 密码。
        /// </summary>
        private string _password;

        /// <summary>
        /// 密码。
        /// </summary>
        public string PassWord
        {
            get =>_password;
            set =>Set(nameof(PassWord),ref _password,value);
        }

        /// <summary>
        /// 真实姓名。
        /// </summary>
        private string _realName;

        /// <summary>
        /// 真实姓名。
        /// </summary>
        public string RealName {
            get => _realName;
            set => Set(nameof(RealName), ref _realName, value);
        }

        private int _phoneNumber;

        /// <summary>
        /// 手机号。
        /// </summary>
        public int PhoneNumber {
            get => _phoneNumber;
            set => Set(nameof(PhoneNumber), ref _phoneNumber, value);
        }

        private string _major;

        /// <summary>
        /// 专业。
        /// </summary>
        public string Major {
            get => _major;
            set => Set(nameof(Major), ref _major, value);
        }

        private int _class;

        /// <summary>
        /// 班级。
        /// </summary>
        public int Class {
            get => _class;
            set => Set(nameof(Class), ref _class, value);
        }

        private int _points;

        /// <summary>
        /// 积分。
        /// </summary>
        public int Points {
            get => _points;
            set => Set(nameof(Points), ref _points, value);
        }

        private string _avatar;

        /// <summary>
        /// 头像。
        /// </summary>
        public string Avatar {
            get => _avatar;
            set => Set(nameof(Avatar), ref _avatar, value);
        }

        private IList<UserMission> UserMissions { get; set; }


    }
}
