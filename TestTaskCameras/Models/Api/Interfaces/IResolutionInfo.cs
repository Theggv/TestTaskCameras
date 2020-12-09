using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskCameras.Models.Api.Interfaces
{
    interface IResolutionInfo
    {
        int Width { get; }
        int Height { get; }

        bool IsEnabled { get; }

        int FpsLimit { get; }
        bool UsePFrames { get; }

        string Type { get; }
    }
}
