using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMeAFavor.Models;
using DoMeAFavor.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Windows.UI.Popups;

namespace DoMeAFavor.ViewModels
{
    public class LoginPageViewModel :ViewModelBase
    {
        private readonly IUserService _userService;

        private readonly INavigationService _navigationService;

        private User _user;

        public User User
        {
            get => _user;
            set => Set(nameof(User), ref _user, value);
        }


        /// <summary>
        /// 登录命令
        /// </summary>
        private RelayCommand _loginCommand;

        /// <summary>
        /// 登录命令
        /// </summary>
        public RelayCommand LoginCommand =>
            _loginCommand ?? (_loginCommand = new RelayCommand(async () =>
                {
                    //TODO when login fail
                    if (await _userService.LoginAsync(User.UserId, User.PassWord) == null)
                    {
                        await new MessageDialog("学号或密码错误，请重新输入！").ShowAsync();
                    }
                    else if (await _userService.LoginAsync(User.UserId, User.PassWord) != null)
                    {
                        await new MessageDialog("登录成功！").ShowAsync();

                        //_navigationService.Navigate(typeof(MyPage));
                    } 
                 
                    //await _userService.LoginAsync(User.UserId, User.PassWord);
                    
                }));


        public LoginPageViewModel()
        {
            _userService = new UserService();
            User = new User();
        }

        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
