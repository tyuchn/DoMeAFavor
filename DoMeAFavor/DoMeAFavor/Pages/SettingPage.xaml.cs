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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace DoMeAFavor
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SettingPage : Page
    {
        public SettingPage()
        {
            this.InitializeComponent();
            
        }

        private void ChangePassWord_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ChangePasswordPage));
        }

        private void ColorComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ImageBrush imageBrush = new ImageBrush();
            if (RedBack.IsSelected)
            {
                imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/2.jpg", UriKind.Absolute));
                PivotLayoutElement.Background = imageBrush;
            }
            if (YellowBack.IsSelected)
            {
                imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/12.jpg", UriKind.Absolute));
                PivotLayoutElement.Background = imageBrush;
            }
            if (WhiteBack.IsSelected)
            {
                imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/4.jpg", UriKind.Absolute));
                PivotLayoutElement.Background = imageBrush;
            }
        }
    }
}
