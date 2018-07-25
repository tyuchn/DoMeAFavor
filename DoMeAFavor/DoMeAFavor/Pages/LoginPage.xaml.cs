﻿using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using Windows.UI.Xaml.Media.Animation;


// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace DoMeAFavor
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class LoginPage : Page
    {
   
        public LoginPage()
        {
            InitializeComponent();
        }
        private void MyPWBox1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //ReadOnlyTB.Text = MyPWBox1.Password;
        }

        private  async void ToLogin_Click(object sender, RoutedEventArgs e)
        {
            await LoginContent.ShowAsync();
        }

        private void LoginContent_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Frame.Navigate(typeof(MissionHallPage), null, new DrillInNavigationTransitionInfo());
        }

        private void ToSignUp_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignUpPage), null, new DrillInNavigationTransitionInfo());
        }
    }
}
