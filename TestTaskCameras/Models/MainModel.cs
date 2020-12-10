using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskCameras.Models.Api;
using TestTaskCameras.Models.Api.Interfaces;
using TestTaskCameras.ViewModels;

namespace TestTaskCameras.Models
{
    public class MainModel : ViewModelBase
    {
        public ChannelConfiguration Configuration
        {
            get => configuration;
            private set => SetProperty(ref configuration, value);
        }

        private ChannelConfiguration configuration;

        public MainModel()
        {

        }

        public async Task LoadConfigurationAsync()
        {
            Configuration = await ApiRequests.GetConfigurationAsync();
        }
    }
}
