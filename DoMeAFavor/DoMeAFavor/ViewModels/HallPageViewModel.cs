using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DoMeAFavor.Models;
using DoMeAFavor.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace DoMeAFavor.ViewModels
{
    /// <summary>
    ///     主页ViewModel类。
    /// </summary>
    public class HallPageViewModel : ViewModelBase
    {
        /// <summary>
        ///     添加命令
        /// </summary>
        private RelayCommand _addCommand;

        /// <summary>
        ///     删除命令
        /// </summary>
        private RelayCommand<Mission> _deleteCommand;

        /// <summary>
        ///     刷新命令。
        /// </summary>
        private RelayCommand _listCommand;
        /******** 私有变量 ********/

        /// <summary>
        ///     任务服务。
        /// </summary>
        private readonly IMissionService _missionService;

        /// <summary>
        ///     选中的任务。
        /// </summary>
        private Mission _selectedMission;
        /// <summary>
        /// 要添加的任务
        /// </summary>
        private Mission _toaddMission;
        /// <summary>
        /// 登录的用户
        /// </summary>
        private User _selectedUser;

        /// <summary>
        ///     保存命令。
        /// </summary>
        //private RelayCommand<Mission> _updateCommand;


        /******** 继承方法 ********/

        /******** 公开方法 ********/
        public HallPageViewModel(IMissionService missionService)
        {
            _missionService = missionService;
            MissionCollection = new ObservableCollection<Mission>();
            TakeOverMissionCollection = new ObservableCollection<Mission>();
            DeliveryMissionCollection = new ObservableCollection<Mission>();
            ExpressMissionCollection = new ObservableCollection<Mission>();
            ToAddMission = new Mission();
            SelectedMission = new Mission();
            SelectedUser= new User();
        }

        /*public HallPageViewModel()
        {
            _missionService = new MissionService();
            MissionCollection = new ObservableCollection<Mission>();
            TakeOverMissionCollection = new ObservableCollection<Mission>();
            DeliveryMissionCollection = new ObservableCollection<Mission>();
            ExpressMissionCollection = new ObservableCollection<Mission>();
            ToAddMission = new Mission();
            SelectedMission = new Mission();
            SelectedUser = new User();
        }*/

        
        //private RelayCommand<Mission> _showDetailsCommand;

        /******** 公开属性 ********/

        /// <summary>
        ///     任务集合。
        /// </summary>
        public ObservableCollection<Mission> MissionCollection { get; }

        /// <summary>
        ///     代课任务集合
        /// </summary>
        public ObservableCollection<Mission> TakeOverMissionCollection { get; }

        /// <summary>
        ///     快递任务集合
        /// </summary>
        public ObservableCollection<Mission> ExpressMissionCollection { get; }

        /// <summary>
        ///     外卖任务集合
        /// </summary>
        public ObservableCollection<Mission> DeliveryMissionCollection { get; }
        /// <summary>
        /// 登陆的用户
        /// </summary>
        public User SelectedUser
        {
            get => _selectedUser;
            set => Set(nameof(SelectedUser), ref _selectedUser, value);
        }
        /// <summary>
        ///     选中的任务。
        /// </summary>
        public Mission SelectedMission
        {
            get => _selectedMission;
            set => Set(nameof(SelectedMission), ref _selectedMission, value);
        }
        /// <summary>
        /// 要添加的任务
        /// </summary>
        public Mission ToAddMission
        {
            get => _toaddMission;
            set => Set(nameof(ToAddMission), ref _toaddMission, value);
        }

        /// <summary>
        ///     刷新命令。
        /// </summary>
        public RelayCommand ListCommand =>
            _listCommand ?? (_listCommand =
                new RelayCommand(async () => { await List(); })); //?? a为空则返回b，否则返回a*/

        /// <summary>
        ///     更新命令。
        /// </summary>
        /*public RelayCommand<Mission> UpdateCommand =>
            _updateCommand ?? (_updateCommand = new RelayCommand<Mission>(
                async mission =>
                {
                    var service = _missionService;
                    await service.UpdateAsync(mission);
                }));*/

        /// <summary>
        ///     删除命令
        /// </summary>
        public RelayCommand<Mission> DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new RelayCommand<Mission>(async mission =>
            {
                var service = _missionService;
                await service.DeleteAsync(mission);
                await List();
            }));

        /// <summary>
        ///     添加命令
        /// </summary>
        public RelayCommand AddCommand =>
            _addCommand ?? (_addCommand =
                new RelayCommand(async () =>
                {
                    await _missionService.AddAsync(ToAddMission,SelectedUser);
                    await List();
                }));

        /******** 私有方法 ********/

        /// <summary>
        ///     执行刷新操作。
        /// </summary>
        private async Task List()
        {
            MissionCollection.Clear();
            TakeOverMissionCollection.Clear();
            DeliveryMissionCollection.Clear();
            ExpressMissionCollection.Clear();

            var missions = await _missionService.ListAsync();
            foreach (var mission in missions)
                if (mission.Type == Mission.MissionType.Express)
                    ExpressMissionCollection.Add(mission);
                else if (mission.Type == Mission.MissionType.TakeOver)
                    TakeOverMissionCollection.Add(mission);
                else if (mission.Type == Mission.MissionType.Delivery) DeliveryMissionCollection.Add(mission);
        }
    }
}