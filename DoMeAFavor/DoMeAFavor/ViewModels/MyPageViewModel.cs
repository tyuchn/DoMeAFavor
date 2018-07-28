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
        

        public User User
        {
            get => _user;
            set => Set(nameof(User), ref _user, value);
        }

        /// <summary>
        /// 刷新命令。
        /// </summary>
        private RelayCommand _updateCommand;

        public RelayCommand UpdateCommand =>
            _updateCommand ?? (_updateCommand = new RelayCommand(async () =>
            {
                
            }));


        public MyPageViewModel() 
        {
            _userService = new UserService();
            User = new User();
        }

        

    }
}
