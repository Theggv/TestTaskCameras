using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using TestTaskCameras.Models.Api;
using TestTaskCameras.Models.Api.Interfaces;
using TestTaskCameras.Models.MJpeg;
using TestTaskCameras.ViewModels;

namespace TestTaskCameras.Models
{
    public class CameraModel: ViewModelBase
    {
        public ChannelInfo Channel => request?.Channel;

        public BitmapImage Frame
        {
            get => frame;
            set => SetProperty(ref frame, value);
        }

        public bool IsEnable => stream.IsStarted;


        private BitmapImage frame;
        private CameraRequest request;
        private readonly MJpegStream stream;


        public CameraModel() 
        {
            stream = new MJpegStream(request);
            stream.OnFrameReady += UpdateFrame;
            stream.Start();
        }


        public void SetRequest(CameraRequest request)
        {
            if(request == null)
                return;

            this.request = request;
            stream.ChangeChannel(request.Channel);
            stream.ChangeResolution(request.Resolution);
        }


        public void Enable() => stream.Start();

        public void Disable() => stream.Stop();

        public void GetPreview()
        {
            stream.Start(MJpegStream.StreamMode.GetPreview);
        }


        private void UpdateFrame(object sender, FrameReadyEventArgs e)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new MemoryStream(e.Frame);
            image.EndInit();
            image.Freeze();

            Frame = image;
        }
    }
}
