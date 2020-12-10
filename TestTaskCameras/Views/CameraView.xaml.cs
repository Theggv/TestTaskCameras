using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestTaskCameras.Models.Api;
using TestTaskCameras.ViewModels;

namespace TestTaskCameras.Views
{
    /// <summary>
    /// Логика взаимодействия для CameraView.xaml
    /// </summary>
    public partial class CameraView : UserControl
    {
        public static readonly DependencyProperty CameraProperty;
        public static readonly DependencyProperty CameraNameProperty;
        public static readonly DependencyProperty IsEnableProperty;

        static CameraView()
        {
            CameraProperty = DependencyProperty.Register(
                "Camera",
                typeof(CameraRequest),
                typeof(CameraView),
                new FrameworkPropertyMetadata(
                    default(CameraRequest)
                    ));

            CameraNameProperty = DependencyProperty.Register("CameraName", typeof(string), typeof(CameraView));
            IsEnableProperty = DependencyProperty.Register("IsEnable", typeof(bool), typeof(CameraView));
        }

        public CameraView()
        {
            InitializeComponent();
        }

        public CameraRequest Camera
        {
            get => (CameraRequest)GetValue(CameraProperty);
            set => SetValue(CameraProperty, value);
        }

        public string CameraName
        {
            get => (string)GetValue(CameraNameProperty);
            set => SetValue(CameraNameProperty, value);
        }

        public bool IsEnable
        {
            get => (bool)GetValue(IsEnableProperty);
            set => SetValue(IsEnableProperty, value);
        }
    }
}
