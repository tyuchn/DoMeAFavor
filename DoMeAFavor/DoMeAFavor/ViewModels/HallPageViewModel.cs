using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Contacts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using DoMeAFavor.Models;
using DoMeAFavor.Services;


namespace DoMeAFavor.ViewModels
{
    /// <summary>
    /// 主页ViewModel类。
    /// </summary>
    public class HallPageViewModel : ViewModelBase
    {
        /******** 私有变量 ********/

        /// <summary>
        /// 任务服务。
        /// </summary>
        private IMissionService _missionService;

        /// <summary>
        /// 选中的任务。
        /// </summary>
        private Mission _selectedMission;

        /// <summary>
        /// 刷新命令。
        /// </summary>
        private RelayCommand _listCommand;

        /// <summary>
        /// 保存命令。
        /// </summary>
        //private RelayCommand<Mission> _updateCommand;

        /// <summary>
        /// 详细信息命令。
        /// </summary>
        //private RelayCommand<Mission> _showDetailsCommand;

        /******** 公开属性 ********/

        /// <summary>
        /// 任务集合。
        /// </summary>
        public ObservableCollection<Mission> MissionCollection
        {
            get;
            private set;
        }

        /// <summary>
        /// 选中的联系人。
        /// </summary>
        public Mission SelectedMission
        {
            get => _selectedMission;
            set => Set(nameof(SelectedMission), ref _selectedMission, value);
        }

        /// <summary>
        /// 刷新命令。
        /// </summary>
        public RelayCommand ListCommand =>
            _listCommand ?? (_listCommand =
                new RelayCommand(async () => { await List(); }));  //?? a为空则返回b，否则返回a

        /// <summary>
        /// 更新命令。
        /// </summary>
        /*public RelayCommand<Mission> UpdateCommand =>
            _updateCommand ?? (_updateCommand = new RelayCommand<Mission>(
                async mission => {
                    var service = _missionService;
                    await service.UpdateAsync(mission);
                }));*/

        /******** 继承方法 ********/

        /******** 公开方法 ********/
        public HallPageViewModel(IMissionService missionService)
        {
            _missionService = missionService;
            MissionCollection = new ObservableCollection<Mission>();
        }
        public HallPageViewModel()
        {
            _missionService= new MissionService();
            MissionCollection = new ObservableCollection<Mission>();
        }

        /******** 私有方法 ********/

        /// <summary>
        /// 执行刷新操作。
        /// </summary>
        private async Task List()
        {
            MissionCollection.Clear();

            var missions = await _missionService.ListAsync();
            foreach (var mission in missions)
            {
                MissionCollection.Add(mission);
            }
        }
    }
}
