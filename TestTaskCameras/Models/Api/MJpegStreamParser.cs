using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestTaskCameras.Models.Api
{
    public class MJpegStreamParser
    {
        public event EventHandler<Image> OnImageReady;
    }
}
