using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.NetworkOperators;
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
        /// 用户类。
        /// </summary>
        ///

        private User _user;

        public User user
        {
            get => _user;
            set => Set(nameof(user),ref _user,value);
        }

        /// <summary>
        /// 注册命令
        /// </summary>
        private RelayCommand _signupCommand;

        /// <summary>
        /// 注册命令
        /// </summary>
        public RelayCommand SignupCommand =>
            _signupCommand ?? (_signupCommand = new RelayCommand(async () =>
            {
                await _userService.AddAsync(user);
            }));

        //构造函数
        public SignupPageViewModel(IUserService userService)
        {
            _userService = userService;
            user = new User();
        }
        public SignupPageViewModel()
        {
            _userService = new UserService();
            user = new User();
        }

    }
}
