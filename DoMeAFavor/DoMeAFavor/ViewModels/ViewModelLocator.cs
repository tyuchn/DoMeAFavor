using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using DoMeAFavor.Models;
using DoMeAFavor.Services;
using GalaSoft.MvvmLight.Ioc;

namespace DoMeAFavor.ViewModels
{
    /// <summary>
    ///     ViewModel定位器。
    /// </summary>
    public class ViewModelLocator
    {

        /// <summary>
        ///     ViewModel定位器单件。
        /// </summary>
        public static readonly ViewModelLocator Instance =
            new ViewModelLocator();

        /// <summary>
        ///     构造函数。
        /// </summary>
        private ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);//设置默认的SimpleIOC
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<IUserService, UserService>();
            SimpleIoc.Default.Register<IMissionService, MissionService>(); 

            SimpleIoc.Default.Register<LoginPageViewModel>();
            SimpleIoc.Default.Register<HallPageViewModel>();
            SimpleIoc.Default.Register<SignupPageViewModel>();
            SimpleIoc.Default.Register(() => new User());
        }

        public User User =>
            SimpleIoc.Default.GetInstance<User>();

        /// <summary>
        ///     获得登录ViewModel。
        /// </summary>
        public LoginPageViewModel LoginPageViewModel =>
            SimpleIoc.Default.GetInstance<LoginPageViewModel>();

        /// <summary>
        ///     获得任务大厅ViewModel。
        /// </summary>
        public HallPageViewModel HallPageViewModel =>
            SimpleIoc.Default.GetInstance<HallPageViewModel>();

        /// <summary>
        ///     获得注册ViewModel。
        /// </summary>
        public SignupPageViewModel SignupPageViewModel =>
            SimpleIoc.Default.GetInstance<SignupPageViewModel>();




    }
}
