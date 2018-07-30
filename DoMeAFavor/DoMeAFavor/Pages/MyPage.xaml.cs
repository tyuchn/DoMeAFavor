using System;
using Windows.ApplicationModel.Activation;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using DoMeAFavor.ViewModels;


// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace DoMeAFavor
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MyPage : Page
    {   /// <summary>
        ///个人主页 
        /// </summary>
        public MyPage()
        {
            InitializeComponent();
            DataContext = ViewModelLocator.Instance.LoginPageViewModel;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            await SaveContentButton.ShowAsync();
        }

        private async void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            await new MessageDialog("退出成功").ShowAsync();
            Frame.Navigate(typeof(LoginPage));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MyPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            var viewModel = (LoginPageViewModel) DataContext;
            viewModel.RefreshCommand.Execute(null);
        }
        

    }
}
