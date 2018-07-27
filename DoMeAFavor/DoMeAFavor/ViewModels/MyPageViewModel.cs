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
    public class MyPageViewModel : ViewModelBase
    {
        private User _user;

        private readonly IUserService _userService;
        

        /// <summary>
        ///     接收任务集合。
        /// </summary>
        public ObservableCollection<Mission> AcceptedMissionCollection { get; }

        /// <summary>
        ///     发布任务集合。
        /// </summary>
        public ObservableCollection<Mission> PublishedMissionCollection { get; }

        public User User
        {
            get => _user;
            set => Set(nameof(User), ref _user, value);
        }

        /// <summary>
        /// 刷新命令。
        /// </summary>
        private RelayCommand _refreshCommand;

        public RelayCommand RefreshCommand =>
            _refreshCommand ?? (_refreshCommand = new RelayCommand(async () =>
            {
                await Refresh();
            }));


        public MyPageViewModel() 
        {
            _userService = new UserService();
            User = new User();
        }

        /// <summary>
        ///     执行刷新操作。
        /// </summary>
        private async Task Refresh()
        {

        }

    }
}
