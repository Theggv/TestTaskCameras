using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TestTaskCameras.Models;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.IO;
using TestTaskCameras.Models.Api;
using System.Linq;

namespace TestTaskCameras
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
