using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestTaskCameras.Models;
using TestTaskCameras.Models.Api;
using TestTaskCameras.Models.Api.Interfaces;

namespace TestTaskCameras.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public CameraViewModel SelectedCamera
        {
            get => selectedCamera;
            set
            {
                if (selectedCamera != value)
                {
                    if (selectedCamera != null)
                        selectedCamera.IsEnable = false;

                    if (value != null)
                        value.IsEnable = true;

                    SetProperty(ref selectedCamera, value);
                    OnPropertyChanged(nameof(CameraVisibility));
                }
            }
        }

        public Visibility CameraVisibility
        {
            get => SelectedCamera != null ? Visibility.Visible : Visibility.Hidden;
        }

        public IReadOnlyCollection<CameraViewModel> AvailableCameras => cameras.AsReadOnly();

        public RelayCommand ReloadConfiguration { get; }


        private readonly MainModel model;

        private readonly List<CameraViewModel> cameras;
        private CameraViewModel selectedCamera;
        private Task taskConfigurationLoading;


        public MainViewModel()
        {
            model = new MainModel();
            cameras = new List<CameraViewModel>();

            model.PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case nameof(model.Configuration):
                        if (model.Configuration == null)
                            break;

                        cameras.Clear();

                        model.Configuration.Channels.ForEach(channel =>
                        {
                            var vm = new CameraViewModel(channel,
                                model.Configuration.MobileServerInfo.Resolutions);

                            cameras.Add(vm);
                        });

                        OnPropertyChanged(nameof(AvailableCameras));

                        break;

                    default:
                        break;
                }
            };

            ReloadConfiguration = new RelayCommand(async () =>
            {
                taskConfigurationLoading = model.LoadConfigurationAsync();
                await taskConfigurationLoading;

                OnPropertyChanged(nameof(ReloadConfiguration));
            }, () =>
            {
                if (taskConfigurationLoading != null &&
                    !taskConfigurationLoading.IsCompleted)
                    return false;

                return true;
            });

            ReloadConfiguration.Execute();
        }
    }
}
