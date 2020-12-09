using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskCameras.Models.Api.Interfaces
{
    interface IChannelInfo
    {
        string Id { get; }
        string Name { get; set; }
        string Description { get; set; }
        string DeviceInfo { get; set; }
        string AttachedToServer { get; set; }

        bool IsDisabled { get; }
        bool IsSoundOn { get; }
        bool IsArchivingEnabled { get; }
        bool IsSoundArchivingEnabled { get; }
        bool AllowedRealtime { get; }
        bool AllowedArchive { get; }
        bool IsPtzOn { get; }
        bool IsTransmitSoundOn { get; }

        string ArchiveMode { get; }
        string ArchiveStreamType { get; }

        bool IsFaceAnalystEnabled { get; }
    }
}
