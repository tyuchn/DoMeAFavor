﻿
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
        private string _comboBox; //下拉框

        public SignUpPage()
        {
            InitializeComponent();
            /*var vm = new SignupPageViewModel(new NavigationService());
            DataContext = vm;*/
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewModel = (SignupPageViewModel)DataContext;

            if (ComputerMajor.IsSelected)
                viewModel.User.Major = "计算机专业";
            else
                if (MarxismMajor.IsSelected)
                viewModel.User.Major = "马克思主义专业";
            else
                if (AutomationMajor.IsSelected)
                viewModel.User.Major = "自动化专业";
            else
                if (SoftwareMajor.IsSelected)
                viewModel.User.Major = "软件专业";
            else
                if (MedicalMajor.IsSelected)
                viewModel.User.Major = "中荷医学专业";
            else
                if (MetallurgicalMajor.IsSelected)
                viewModel.User.Major = "冶金专业";
            else
                viewModel.User.Major = null;
        }
        
        

    }
}