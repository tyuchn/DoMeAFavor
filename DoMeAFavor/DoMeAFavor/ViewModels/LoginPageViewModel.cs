using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMeAFavor.Models;
using DoMeAFavor.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace DoMeAFavor.ViewModels
{
    public class LoginPageViewModel :ViewModelBase
    {
        private readonly IUserService _userService;

        private User _user;

        public User user
        {
            get => _user;
            set => Set(nameof(user), ref _user, value);
        }


        /// <summary>
        /// 登录命令
        /// </summary>
        private RelayCommand _loginCommand;

        /// <summary>
        /// 登录命令
        /// </summary>
        public RelayCommand SignupCommand =>
            _loginCommand ?? (_loginCommand = new RelayCommand(async () =>
            {
                


            }));


        public LoginPageViewModel()
        {
            _userService = new UserService();
            user = new User();
        }
    }
}
