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
    public class CameraModel : ViewModelBase
    {
        public ChannelInfo Channel => channel;

        public BitmapImage Frame
        {
            get => frame;
            set => SetProperty(ref frame, value);
        }

        public bool IsEnable => stream.IsStarted;

        private readonly MJpegStream stream;
        private BitmapImage frame;
        private readonly MemoryStream memoryStream;

        private ChannelInfo channel;
        private ResolutionInfo resolution;


        public CameraModel()
        {
            stream = new MJpegStream(channel, resolution);
            stream.OnFrameReady += UpdateFrame;

            memoryStream = new MemoryStream();
        }


        public void SetChannel(ChannelInfo channel)
        {
            if (channel == null)
                return;

            this.channel = channel;
            stream.ChangeChannel(channel);
        }

        public void SetResolution(ResolutionInfo resolution)
        {
            if (resolution == null)
                return;

            this.resolution = resolution;
            stream.ChangeResolution(resolution);
        }

        public void Enable() => stream.Start();

        public void Disable() => stream.Stop();

        public void GetPreview()
        {
            stream.Start(MJpegStream.StreamMode.GetPreview);
        }


        private void UpdateFrame(object sender, FrameReadyEventArgs e)
        {
            try
            {
                memoryStream.Position = 0;
                memoryStream.SetLength(0);
                memoryStream.Write(e.Frame, 0, e.Frame.Length - 1);
                memoryStream.Seek(0, SeekOrigin.Begin);

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = new MemoryStream(e.Frame);
                image.EndInit();
                image.Freeze();

                Frame = image;
            }
            catch (Exception ex) { }
        }
    }
}
