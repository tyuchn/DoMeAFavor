using System;

using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace DoMeAFavor
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ChangePasswordPage : Page
    {
        public ChangePasswordPage()
        {
            InitializeComponent();
        }

        private async void yes_Click(object sender, RoutedEventArgs e)
        {
            string oldPasswordBox = OldPasswordBox.Password; //老密码栏输入内容
            string newPasswordBox = NewPasswordBox.Password;  //新密码栏输入内容
            string sureNewPasswordBox = SureNewPasswordBox.Password;   //确认新密码栏输入内容
            //判断老密码是否正确
            if (oldPasswordBox == "20154416")
            {
                //判断新密码输入两次是否相同
                if (newPasswordBox == sureNewPasswordBox)
                {
                     await new MessageDialog("修改密码成功").ShowAsync();
                    Frame.Navigate(typeof(SettingPage));
                }
                else await new MessageDialog("两次密码输入不同").ShowAsync();
            }
            else await new MessageDialog("原密码输入错误").ShowAsync();
           
        }

        private void ChangePassWord_Click(object sender, RoutedEventArgs e)
        {
           // Frame.Navigate(typeof(ChangePasswordPage));
        }
        /// <summary>
        /// 修改密码中途退出判别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Exit_Click(object sender, RoutedEventArgs e)
        {
            string oldPasswordBox = OldPasswordBox.Password;
            string newPasswordBox = NewPasswordBox.Password;
            string sureNewPasswordBox = SureNewPasswordBox.Password;
            if ((oldPasswordBox == null) && (newPasswordBox == null) && (sureNewPasswordBox == null))
                Frame.Navigate(typeof(SettingPage));
            else
                await SureExitContent.ShowAsync();
        }
        /// <summary>
        /// 若修改密码的三个栏没有为空则提醒是否放弃修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void SureExitContent_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Frame.Navigate(typeof(SettingPage));
        }
    }
}
