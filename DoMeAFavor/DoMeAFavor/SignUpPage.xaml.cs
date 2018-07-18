using DoMeAFavor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        public SignUpPage()
        {
            this.InitializeComponent();
        }

        private void SureSignUp_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MissionHallPage));
        }
        private void Init()
        {
            List<Major> majors = new List<Major>();
            /*for (int i = 0; i < 5; i++)
            {
                Major major = new Major();
                major.Name = "专业" + i;
              
                majors.Add(major);
            }*/
            Major major = new Major();
            major.Name = "zhuanye";
            majors.Add(major);
            MajorComboBox.ItemsSource = majors;
            MajorComboBox.DisplayMemberPath = "Name";//显示字段
            MajorComboBox.SelectedIndex = 0;
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
