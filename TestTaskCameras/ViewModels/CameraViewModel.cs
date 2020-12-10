using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using TestTaskCameras.Models;
using TestTaskCameras.Models.Api.Interfaces;

namespace TestTaskCameras.ViewModels
{
    public class CameraViewModel: ViewModelBase
    {
        public BitmapImage Frame
        {
            get => frame;
            set => SetProperty(ref frame, value);
        }

        public string Name => model.Channel?.Name;

        public bool IsEnable
        {
            get => isEnable;
            set
            {
                SetProperty(ref isEnable, value);

                if (isEnable)
                {
                    model.Enable();
                }
                else model.Disable();
            }
        }

        public RelayCommand LowResolution { get; }
        public RelayCommand MiddleResolution { get; }
        public RelayCommand HighResolution { get; }


        private readonly CameraModel model;
        private IEnumerable<ResolutionInfo> availableResolutions;
        private ResolutionInfo selectedResolution;

        private BitmapImage frame;
        private bool isEnable;


        public CameraViewModel(ChannelInfo channel, IEnumerable<ResolutionInfo> resolutions)
        {
            model = new CameraModel();
            model.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(model.Frame))
                {
                    Frame = model.Frame;
                }
                else if (e.PropertyName == nameof(model.Channel))
                {
                    OnPropertyChanged(nameof(Name));
                }
            };

            model.SetChannel(channel);
            model.GetPreview();

            availableResolutions = resolutions;
            selectedResolution = resolutions.
                FirstOrDefault(x => x.Type == "Low");

            LowResolution = new RelayCommand(() =>
            {
                var res = availableResolutions
                    .FirstOrDefault(x => x.Type == "Low");

                selectedResolution = res;
                ChangeResolution(selectedResolution);
            }, () =>
            {
                var res = availableResolutions
                    .FirstOrDefault(x => x.Type == "Low");

                return res != null && selectedResolution != res;
            });

            MiddleResolution = new RelayCommand(() =>
            {
                var res = availableResolutions
                      .FirstOrDefault(x => x.Type == "Middle");

                selectedResolution = res;
                ChangeResolution(selectedResolution);
            }, () => 
            {
                var res = availableResolutions
                    .FirstOrDefault(x => x.Type == "Middle");

                return res != null && selectedResolution != res;
            });

            HighResolution = new RelayCommand(() =>
            {
                var res = availableResolutions
                       .FirstOrDefault(x => x.Type == "High");

                selectedResolution = res;
                ChangeResolution(selectedResolution);
            }, () => 
            {
                var res = availableResolutions
                     .FirstOrDefault(x => x.Type == "High");

                return res != null && selectedResolution != res;
            });
        }

        public void ChangeResolution(ResolutionInfo resolution)
        {
            model.SetResolution(resolution);
        }
    }
}
