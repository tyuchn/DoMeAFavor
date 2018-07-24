using DoMeAFavor.Models;
using DoMeAFavor.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace DoMeAFavor
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SignUpPage : Page
    {
        private string _comboBox; //下拉框

        public SignUpPage()
        {
            this.InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _comboBox = MajorComboBox.SelectedItem.ToString();
        }

        private void SureInformation_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
        /// <summary>
        /// 点击时给下拉框的值赋予给user.Major
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            
            var viewModel = (SignupPageViewModel)DataContext;
            viewModel.user.Major = _comboBox;
            await SureInformation.ShowAsync();
        }

        //确认注册信息的点击事件
        private void SureInformation_OnPrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Frame.Navigate(typeof(MyPage));
        }
    }
}