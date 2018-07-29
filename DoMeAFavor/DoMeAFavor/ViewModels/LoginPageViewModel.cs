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
using Windows.UI.Popups;

namespace DoMeAFavor.ViewModels
{
    public class LoginPageViewModel :ViewModelBase
    {
        private readonly IUserService _userService;

        private readonly INavigationService _navigationService;


        /// <summary>
        ///     接收任务集合。
        /// </summary>
        public ObservableCollection<Mission> AcceptedMissionCollection { get; }

        /// <summary>
        ///     发布任务集合。
        /// </summary>
        public ObservableCollection<Mission> PublishedMissionCollection { get; }
        /// <summary>
        /// 用户
        /// </summary>
        private User _user;
        /// <summary>
        /// 用户
        /// </summary>
        public User User
        {
            get => _user;
            set => Set(nameof(User), ref _user, value);
        }
        /// <summary>
        /// 验证码数据
        /// </summary>
        private string _captchaBox;
        public string CaptchaBox
        {
            get => _captchaBox;
            set => Set(nameof(CaptchaBox), ref _captchaBox, value);
        }
        private string _captchaText="1258";
        public string CaptchaText
        {
            get => _captchaText;
            set => Set(nameof(CaptchaText), ref _captchaText, value);
            
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
                    if(CaptchaBox==CaptchaText)
                    { 
                    if (await _userService.LoginAsync(User.UserId, User.PassWord) == null)
                    {
                        await new MessageDialog("学号或密码错误，请重新输入！").ShowAsync();

                    }
                    else if (await _userService.LoginAsync(User.UserId, User.PassWord) != null)
                    {
                        await new MessageDialog("登录成功！").ShowAsync();
                        _navigationService.Navigate(typeof(MyPage));
                            await List(User.UserId,User.PassWord);
                    }
                    }
                    else
                        await new MessageDialog("验证码错误").ShowAsync();

                }));
        
        /// <summary>
        /// 更新指令
        /// </summary>
        private RelayCommand _updateCommand;
        
        /// <summary>
        /// 更新指令
        /// </summary>
        public RelayCommand UpdateCommand =>
            _updateCommand ?? (_updateCommand = new RelayCommand(async () =>
            {
                var service = _userService;
                await service.UpdateAsync(User);
            }));
        
        /// <summary>
        /// 刷新指令
        /// </summary>
        private RelayCommand _refreshCommand;
        
        /// <summary>
        /// 刷新指令
        /// </summary>
        public RelayCommand RefreshCommand => _refreshCommand ?? (_refreshCommand = 
                                                  new RelayCommand(
                                                  async () => 
                                                  { await List(User.UserId, User.PassWord)
                                                      ; }
                                              ));
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="navigationService"></param>
        /// <param name="userService"></param>
        public LoginPageViewModel(INavigationService navigationService,IUserService userService)
        {
            _userService = userService;
            _navigationService = navigationService;
            User = new User();
            AcceptedMissionCollection = new ObservableCollection<Mission>();
            PublishedMissionCollection = new ObservableCollection<Mission>();
        }
        
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private async Task List(string userid, string password)
        {
            
            AcceptedMissionCollection.Clear();
            PublishedMissionCollection.Clear();
            User = await _userService.LoginAsync(userid, password);
            var acceptedmissions = await _userService.GetAcceptedMissionsAsync(userid,password);
            var publishedmissions = await _userService.GetPublishedMissionsAsync(userid,password);
            foreach (var mission in acceptedmissions)
            {
                AcceptedMissionCollection.Add(mission);
            }
            foreach (var mission in publishedmissions)
            {
                PublishedMissionCollection.Add(mission);
            }

        }
    }
}
