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

        private User _user;

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
                        await List(User.UserId,User.PassWord);
                    }
                    }
                    else
                        await new MessageDialog("验证码错误").ShowAsync();

                }));
        private RelayCommand _updateCommand;

        public RelayCommand UpdateCommand =>
            _updateCommand ?? (_updateCommand = new RelayCommand(async () =>
            {
                var service = _userService;
                await service.UpdateAsync(User);
            }));

       /* public LoginPageViewModel()
        {
            _userService = new UserService();
            User = new User();
            AcceptedMissionCollection = new ObservableCollection<Mission>();
            PublishedMissionCollection = new ObservableCollection<Mission>();

        }*/



        public LoginPageViewModel(INavigationService navigationService)
        {
            _userService = new UserService();
            _navigationService = navigationService;
            User = new User();
            AcceptedMissionCollection = new ObservableCollection<Mission>();
            PublishedMissionCollection = new ObservableCollection<Mission>();
        }
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
