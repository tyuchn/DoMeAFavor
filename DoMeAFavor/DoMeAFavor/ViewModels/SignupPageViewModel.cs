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


        public SignupPageViewModel(IUserService userService)
        {

        }





    }
}
