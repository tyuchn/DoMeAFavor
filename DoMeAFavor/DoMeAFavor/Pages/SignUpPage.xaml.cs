using DoMeAFavor.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


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
            InitializeComponent();
            /*var vm = new SignupPageViewModel(new NavigationService());
            DataContext = vm;*/
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _comboBox = MajorComboBox.SelectedItem.ToString();
        }

        /// <summary>
        /// 点击时给下拉框的值赋予给user.Major
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (SignupPageViewModel)DataContext;
            if (SurePassword.Password == Password.Password)
            {
                if (ComputerMajor.IsSelected)
                    viewModel.user.Major = "计算机专业";
                else
                    if (MarxismMajor.IsSelected)
                    viewModel.user.Major = "马克思主义专业";
                else
                    if (AutomationMajor.IsSelected)
                    viewModel.user.Major = "自动化专业";
                else
                    if (SoftwareMajor.IsSelected)
                    viewModel.user.Major = "软件专业";
                else
                    if (MedicalMajor.IsSelected)
                    viewModel.user.Major = "中荷医学专业";
                else
                    if (MetallurgicalMajor.IsSelected)
                    viewModel.user.Major = "冶金专业";
                else
                    viewModel.user.Major = null;
            }
            else
                await new MessageDialog("两次输入密码不同").ShowAsync();
        }

    }
}