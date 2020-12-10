using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskCameras.Models.Api.Interfaces;

namespace TestTaskCameras.Models.Api
{
    public class CameraRequest
    {
        public ChannelInfo Channel { get; set; }

        public ResolutionInfo Resolution { get; set; }
    }
}
