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
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace DoMeAFavor.ViewModels
{
    public class SignupPageViewModel : ViewModelBase
    {

        private IUserService _userService;

        /// <summary>
        /// 用户类。
        /// </summary>

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

               if(user.UserId.ToString().Length==8)
                {
                    if (user.PassWord.Length<16)
                    {
                        if(user.PassWord=="22222")
                        {
                            if (user.RealName != null)
                            {
                                if (user.PhoneNumber.ToString().Length == 11)
                                {
                                    if (user.UserName != null)
                                    {
                                        if (user.Major != null)
                                        {
                                            if (user.Class.ToString().Length==4)
                                            { 
                                                await _userService.AddAsync(user);
                                                await new MessageDialog("注册成功").ShowAsync(); 
                                                //Frame.
                                            }
                                            else
                                                await new MessageDialog("请输入正确班级号如：1505").ShowAsync();
                                        }
                                        else
                                            await new MessageDialog("请选择专业").ShowAsync();
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
