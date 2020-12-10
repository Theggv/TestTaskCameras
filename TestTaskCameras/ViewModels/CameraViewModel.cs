using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using TestTaskCameras.Models;
using TestTaskCameras.Models.Api;

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

        public CameraRequest Camera
        {
            get => request;
            set
            {
                SetProperty(ref request, value);
                model.SetRequest(value);
            }
        }

        public bool IsEnable
        {
            get => isEnable;
            set
            {
                SetProperty(ref isEnable, value);

                if (isEnable) model.Enable();
                else model.Disable();
            }
        }


        private readonly CameraModel model;

        private CameraRequest request;
        private BitmapImage frame;
        private bool isEnable;


        public CameraViewModel()
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
        }

        public void GetPreview() => model.GetPreview();
    }
}
