
using Windows.UI.Xaml;
using DoMeAFavor.ViewModels;
using Windows.UI.Xaml.Controls;


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
            InitializeComponent();
            DataContext = ViewModelLocator.Instance.SignupPageViewModel;
        }

       

        private void SignUpPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            //每次重新加载界面，textbox里的内容清除
            UserIdTextBox.Text = "";
            PasswordTextBox.Password = "";
            ConfirmPasswordTextBox.Password = "";
            RealNameTextBox.Text = "";
            PhoneNumberTextBox.Text = "";
            UserNameTextBox.Text = "";
        }
    }
}