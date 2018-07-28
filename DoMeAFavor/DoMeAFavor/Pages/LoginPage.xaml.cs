using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using Windows.UI.Xaml.Media.Animation;
using DoMeAFavor.Services;
using DoMeAFavor.ViewModels;
using Windows.UI.Popups;


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
            DataContext = ViewModelLocator.Instance.LoginPageViewModel;

        }
        private void MyPWBox1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //ReadOnlyTB.Text = MyPWBox1.Password;
        }

        private  async void ToLogin_Click(object sender, RoutedEventArgs e)
        {
            // Captcha.Background = "red";
           // CaptchaText.Foreground = Color;
            GetCode();
            await LoginContent.ShowAsync();
           
        }

        

        private  void ToSignUp_Click(object sender, RoutedEventArgs e)
        {
          
            Frame.Navigate(typeof(SignUpPage), null, new DrillInNavigationTransitionInfo());
        }
        /// <summary>
        /// 生成随机验证码
        /// </summary>
        public void GetCode()
        {
            string vc = "";
            Random r = new Random();
            int num1 = r.Next(0, 9);
            int num2 = r.Next(0, 9);
            int num3 = r.Next(0, 9);
            int num4 = r.Next(0, 9);

            int[] numbers = new int[4] { num1, num2, num3, num4 };
            for (int i = 0; i < numbers.Length; i++)
            {
                vc += numbers[i].ToString();
            }
            CaptchaText.Text = vc;
        }
    }
}
