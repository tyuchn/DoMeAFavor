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
using DoMeAFavor.Models;
using DoMeAFavor.ViewModels;
using System.Diagnostics;
using System.Threading;
using System.Timers;
// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace DoMeAFavor
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MissionHallPage : Page
    {
        public MissionHallPage()
        {
            this.InitializeComponent();

            DispatcherTimer time = new DispatcherTimer();
            time.Interval = new TimeSpan(0, 0,3);
            time.Tick += Time_Tick;
            time.Start();

        }

        private void SearchText_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

        }

        private void SearchText_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

        }

        private void SearchText_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {

        }

        private async void HallGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var viewModel = (HallPageViewModel) DataContext;
            viewModel.SelectedMission = (Mission) e.ClickedItem;
            await MissionDetailContent.ShowAsync();
        }

        private async void AddButton_Click_1(object sender, RoutedEventArgs e)
        {
            await AddMissionContent.ShowAsync();
        }
        
        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewModel = (HallPageViewModel)DataContext;
            if (TakeOver.IsSelected)
            {            
                viewModel.ToAddMission.Type = Mission.MissionType.TakeOver;
            }
            else if (Delivery.IsSelected)
            {
                viewModel.ToAddMission.Type = Mission.MissionType.Delivery;
            }
            else if (Express.IsSelected)
            {
                viewModel.ToAddMission.Type = Mission.MissionType.Express;
            }
        }

        
             private void Time_Tick(object sender, object e)
        {
            int i = MissionHallFlip.SelectedIndex;
            i++;
            if (i >= MissionHallFlip.Items.Count)
            {
                i = 0;
            }
            MissionHallFlip.SelectedIndex = i;
        }
    }
}
