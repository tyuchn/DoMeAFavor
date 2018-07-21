using DoMeAFavor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace DoMeAFavor
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SignUpPage : Page
    {
        private string _comboBox;
        public SignUpPage()
        {
            this.InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _comboBox = MajorComboBox.SelectedItem.ToString();

        }
        private async void SureSignUp_Click(object sender, RoutedEventArgs e)
        {
            int count=0;
            string userId = UserId.Text;
            string password = Password.Password;
            string surePassword = SurePassword.Password;
            string phoneNumber = PhoneNumber.Text;
            string reallyName = ReallyName.Text;
            string netName = NetName.Text;
            string _class = Class.Text;
            if (userId.Length == 8)
                count++;
            
            else
                await new MessageDialog(" 学号位数不对").ShowAsync();
            if ((password == surePassword)&&(password.Length<17))
                count++;
            else
                await new MessageDialog(" 请检测密码格式或重新确认密码").ShowAsync();
            if(phoneNumber.Length==11)
            count++;
            else
                await new MessageDialog(" 手机号有误").ShowAsync();
            if(reallyName!=null)
                count++;
            else
                await new MessageDialog(" 请填写真实姓名").ShowAsync();
            if (_comboBox != null)
                count++;
            else
                await new MessageDialog(" 请选择专业").ShowAsync();
            if(count==5)
                Frame.Navigate(typeof(MissionHallPage));
        }


       
    }
}
