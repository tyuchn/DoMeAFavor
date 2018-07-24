using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMeAFavor.Models;
using DoMeAFavor.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace DoMeAFavor.ViewModels
{
    public class SignupPageViewModel : ViewModelBase
    {

        private IUserService _userService;

        /// <summary>
        /// 用户集合。
        /// </summary>
        public ObservableCollection<User> UsersCollection
        {
            get;
            private set;
        }

        /// <summary>
        /// 注册命令
        /// </summary>
        private RelayCommand _signupCommand;

        /// <summary>
        /// 注册命令
        /// </summary>
        // public RelayCommand SignupCommand =>


        //构造函数
        public SignupPageViewModel(IUserService userService)
        {
            _userService = userService;
            UsersCollection = new ObservableCollection<User>();
        }
        public SignupPageViewModel()
        {
            _userService = new UserService();
            UsersCollection = new ObservableCollection<User>();
        }





    }
}
