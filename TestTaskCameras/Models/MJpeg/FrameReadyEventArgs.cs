using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskCameras.Models.MJpeg
{
    public class FrameReadyEventArgs: EventArgs
    {
        public byte[] Frame { get; set; }
    }
}
