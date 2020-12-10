using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskCameras.Models;
using TestTaskCameras.Models.Api;
using TestTaskCameras.Models.Api.Interfaces;

namespace TestTaskCameras.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly MainModel model;

        private readonly List<CameraViewModel> cameras;
        private CameraViewModel selectedCamera;

        public CameraViewModel SelectedCamera
        {
            get => selectedCamera;
            set
            {
                if (selectedCamera != value)
                {
                    if(selectedCamera != null)
                        selectedCamera.IsEnable = false;

                    value.IsEnable = true;

                    SetProperty(ref selectedCamera, value);
                }
            }
        }

        public IReadOnlyCollection<CameraViewModel> OtherCameras => cameras.AsReadOnly();


        public MainViewModel()
        {
            model = new MainModel();
            cameras = new List<CameraViewModel>();

            model.PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case nameof(model.Configuration):
                        model.Configuration.Channels.ForEach(channel =>
                        {
                            var vm = new CameraViewModel
                            {
                                Camera = new CameraRequest { Channel = channel }
                            };

                            vm.GetPreview();

                            cameras.Add(vm);
                        });

                        OnPropertyChanged(nameof(OtherCameras));

                        break;

                    default:
                        break;
                }
            };

            Task.Run(async() => await model.LoadConfigurationAsync());
        }
    }
}
