using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using DoMeAFavor.Models;
using DoMeAFavor.ViewModels;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Windows.UI.Xaml.Navigation;
using DoMeAFavor.Services;
using System.Threading.Tasks;

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
            suggestions = new ObservableCollection<Mission>();
            suggestions1 = new ObservableCollection<string>();
            DispatcherTimer time = new DispatcherTimer();
            time.Interval = new TimeSpan(0, 0,3);
            time.Tick += Time_Tick;
            time.Start();

        }

        /// <summary>
        /// 搜索服务
        /// </summary>
        private ObservableCollection<Mission> suggestions;
        private ObservableCollection<string> suggestions1;

        private void SearchText_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var viewModel = (HallPageViewModel)DataContext;
             var i = viewModel.MissionCollection.Count;
            int j;
            suggestions1.Clear();
            for(j= 0; j< i; j++)   
            { 
                if(viewModel.MissionCollection[j].MissionName.Contains(sender.Text))
            suggestions1.Add(viewModel.MissionCollection[j].MissionName);
            }
           
            sender.ItemsSource= suggestions1;
        }
       
        private  async void SearchText_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            var viewModel = (HallPageViewModel)DataContext;
            if (args.ChosenSuggestion != null)
            {
                await MissionDetailContent.ShowAsync();
            }
            
        }

        private  void SearchText_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var viewModel = (HallPageViewModel)DataContext;
            int a;
            for (a = 0;a < viewModel.MissionCollection.Count;a++)
            {
                if (viewModel.MissionCollection[a].MissionName == args.SelectedItem)
                    viewModel.SelectedMission = viewModel.MissionCollection[a];
            }
            
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

        /// <summary>
        /// 图片滑动方式，顺序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        private void MissionHallPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            var viewModel = (HallPageViewModel) DataContext;
            viewModel.ListCommand.Execute(null);
            MissionNameTextBox.Text = "sd";
            MessageTextBox.Text = "";
            PointsTextBox.Text = "";
        }
    }
}
