using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using DoMeAFavor.Models;
using DoMeAFavor.ViewModels;
using System.Collections.ObjectModel;
using Windows.UI.Popups;

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
            InitializeComponent();
            DataContext = ViewModelLocator.Instance.HallPageViewModel;
            suggestions = new ObservableCollection<string>();
            DispatcherTimer time = new DispatcherTimer();
            time.Interval = new TimeSpan(0, 0,3);
            time.Tick += Time_Tick;
            time.Start();

        }
        private ObservableCollection<String> suggestions;

        private void SearchText_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var i = 0;
            suggestions.Clear();
            for(i= 0; i < 5; i++)   
            { 
            suggestions.Add(sender.Text + "1");
            }
            sender.ItemsSource = suggestions;
        }

        private void SearchText_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
           /* if (args.ChosenSuggestion != null)
                SearchBlock.Text = args.ChosenSuggestion.ToString();
            else
                SearchBlock.Text = sender.Text;*/
        }

        private async void SearchText_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            await new MessageDialog("暂无任务").ShowAsync();
        }
        /// <summary>
        /// 点击任务后触发事假
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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



        private void MissionHallPage_OnLoading(FrameworkElement sender, object args)
        {
            var viewmodel =(HallPageViewModel) DataContext;
            viewmodel.ListCommand.Execute(null);
        }
    }
}
