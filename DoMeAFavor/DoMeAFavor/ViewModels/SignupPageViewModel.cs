using System;

using DoMeAFavor.Models;
using DoMeAFavor.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace DoMeAFavor.ViewModels
{
    public class SignupPageViewModel : ViewModelBase
    {

        private  readonly IUserService _userService;

        private readonly INavigationService _navigationService;

        /// <summary>
        /// 用户类。
        /// </summary>
        private string _password;
        public string SurePassword { get=>_password;
            set=> Set(nameof(SurePassword), ref _password, value);
        }

        private User _user;
        
        public User User
        {
            get => _user;
            set => Set(nameof(User),ref _user,value);
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
               if(User.UserId.Length==8)
                {
                    if (User.PassWord.Length<16)
                    {
                        if(User.PassWord==SurePassword)
                        {
                            if (User.RealName != null)
                            {
                                if (User.PhoneNumber.Length == 11)
                                {
                                    if (User.UserName != null)
                                    {
                                                await _userService.AddAsync(User);
                                                //var cd = new ContentDialog();
                                                var messageDialog = new MessageDialog("注册成功");                                               
                                                messageDialog.Commands.Add(new UICommand("确定", cmd =>
                                                {
                                                    _navigationService.Navigate(typeof(MyPage));
                                                }));
                                                await messageDialog.ShowAsync();                                          
                                    }
                                    else
                                        await new MessageDialog("请填写用户昵称").ShowAsync();
                                }
                                else
                                    await new MessageDialog("手机号有误").ShowAsync();
                            }
                            else
                                await new MessageDialog("请填写真实姓名").ShowAsync();
                        }
                        else
                            await new MessageDialog("两密码栏输入不同，请重新输入").ShowAsync();
                    }
                    else
                        await new MessageDialog("密码长度有误").ShowAsync();
                }
                else
                    await new MessageDialog(" 学号位数不对").ShowAsync();
                
                
            }));

      

        //构造函数
        /*public SignupPageViewModel(IUserService userService)
        {
            _userService = userService;
            User = new User();
        }
        public SignupPageViewModel()
        {
            _userService = new UserService();
            User = new User();
        }*/
        public SignupPageViewModel(IUserService userService,INavigationService navigationService)
        {
            _userService = userService;
            User = new User();
            _navigationService = navigationService;
        }

    }
}
