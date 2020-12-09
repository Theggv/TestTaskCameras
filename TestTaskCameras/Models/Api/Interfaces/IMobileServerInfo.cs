using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskCameras.Models.Api.Interfaces
{
    interface IMobileServerInfo
    {
        bool IsEnabled { get; }

        bool IsProxyEnabled { get; }
        bool IsMobilePushEnabled { get; }
        int Port { get; }

        bool UsePFrames { get; }
        int FpsLimit { get; }

        string LowResolution { get; }
        string MiddleResolution { get; }
        string HighResolution { get; }

        List<IResolutionInfo> Resolutions { get; }
    }
}
