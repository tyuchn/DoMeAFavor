
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using Windows.UI.Xaml.Input;
using DoMeAFavor.Services;


// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace DoMeAFavor
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public static MainPage Current;

        public MainPage()
        {
            InitializeComponent();
            HomeFrame.Navigate(typeof(MissionHallPage));
            Current = this;
        }

        private void NavigationView_OnSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem item =
                args.SelectedItem as NavigationViewItem;

            HomeFrame.Navigate(typeof(MissionHallPage));
            switch (item.Tag)
            {
                case "MyPage":
                   // if(UserState==1)
                    HomeFrame.Navigate(typeof(MyPage));
                    break;
                case "MissionHall":

                    HomeFrame.Navigate(typeof(MissionHallPage));
                    break;
                case "NoLoginMyPage":
                    HomeFrame.Navigate(typeof(LoginPage));
                    break;
                case "MyMoney":
                    HomeFrame.Navigate(typeof(MyMoneyPage));
                    break;


            }
           
        }
        private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            On_BackRequested();
        }

        private void BackInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            On_BackRequested();
            args.Handled = true;
        }

        private bool On_BackRequested()
        {
            bool navigated = false;

            // don't go back if the nav pane is overlayed
            if (DoMeAFavor.IsPaneOpen && (DoMeAFavor.DisplayMode == NavigationViewDisplayMode.Compact || DoMeAFavor.DisplayMode == NavigationViewDisplayMode.Minimal))
            {
                return false;
            }
            else
            {
                if (HomeFrame.CanGoBack)
                {
                    HomeFrame.GoBack();
                    navigated = true;
                }
            }
            return navigated;
        }

        private void DoMeAFavor_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                HomeFrame.Navigate(typeof(SettingPage));
            }
        }

        

        

        
    }
}
