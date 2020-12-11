using System;

namespace TestTaskCameras.Models.MJpeg
{
    public class FrameReadyEventArgs: EventArgs
    {
        public byte[] Frame { get; set; }
    }
}
