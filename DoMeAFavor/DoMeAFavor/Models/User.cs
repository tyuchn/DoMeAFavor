using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace DoMeAFavor.Models
{
    /// <summary>
    ///     用户类
    /// </summary>
    public class User : ObservableObject
    {
        private string _avatar;

        private string _class;

        private string _major;

        /// <summary>
        ///     密码。
        /// </summary>
        private string _password;

        private string _phoneNumber;

        private int _points;

        /// <summary>
        ///     真实姓名。
        /// </summary>
        private string _realName;

        /// <summary>
        ///     学号
        /// </summary>
        private string _userId;

        /// <summary>
        ///     用户名
        /// </summary>
        private string _userName;

        /// <summary>
        ///     主键。
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     学号
        /// </summary>
        public string UserId
        {
            get => _userId;
            set => Set(nameof(UserId), ref _userId, value);
        }

        /// <summary>
        ///     用户名
        /// </summary>
        public string UserName
        {
            get => _userName;
            set => Set(nameof(UserName), ref _userName, value);
        }

        /// <summary>
        ///     密码。
        /// </summary>
        public string PassWord
        {
            get => _password;
            set => Set(nameof(PassWord), ref _password, value);
        }

        /// <summary>
        ///     真实姓名。
        /// </summary>
        public string RealName
        {
            get => _realName;
            set => Set(nameof(RealName), ref _realName, value);
        }

        /// <summary>
        ///     手机号。
        /// </summary>
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => Set(nameof(PhoneNumber), ref _phoneNumber, value);
        }

        /// <summary>
        ///     专业。
        /// </summary>
        public string Major
        {
            get => _major;
            set => Set(nameof(Major), ref _major, value);
        }

        /// <summary>
        ///     班级。
        /// </summary>
        public string Class
        {
            get => _class;
            set => Set(nameof(Class), ref _class, value);
        }

        /// <summary>
        ///     积分。
        /// </summary>
        public int Points
        {
            get => _points;
            set => Set(nameof(Points), ref _points, value);
        }

        /// <summary>
        ///     头像。
        /// </summary>
        public string Avatar
        {
            get => _avatar;
            set => Set(nameof(Avatar), ref _avatar, value);
        }

        public IList<UserMission> UserMissions { get; set; }
    }
}