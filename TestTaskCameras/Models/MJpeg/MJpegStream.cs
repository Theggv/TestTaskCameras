using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using TestTaskCameras.Models.Api;
using TestTaskCameras.Models.Api.Interfaces;

namespace TestTaskCameras.Models.MJpeg
{
    public class MJpegStream : IDisposable
    {
        public enum StreamMode
        {
            GetPreview, // Will stop streaming when first frame was receive
            Streaming,
        };

        /// <summary>
        /// Calls when another frame was found
        /// </summary>
        public event EventHandler<FrameReadyEventArgs> OnFrameReady;

        public bool IsStarted => isStarted;


        private bool isStarted = false;
        private StreamMode streamMode;

        private readonly CameraRequest cameraRequest;
        private readonly MJpegStreamParser parser;
        private CancellationTokenSource cts;


        public MJpegStream(CameraRequest request) :
            this(request?.Channel, request?.Resolution)
        { }

        public MJpegStream(ChannelInfo channel, ResolutionInfo resolution = null)
        {
            cameraRequest = new CameraRequest
            {
                Channel = channel,
                Resolution = resolution,
            };

            parser = new MJpegStreamParser();
            parser.OnFrameReady += (s, e) =>
            {
                OnFrameReady?.Invoke(s, e);

                if (streamMode == StreamMode.GetPreview)
                    Stop();
            };
        }


        public void Start(StreamMode mode = StreamMode.Streaming)
        {
            if (isStarted || cameraRequest == null || cameraRequest.Channel == null)
                return;

            isStarted = true;
            streamMode = mode;
            cts = new CancellationTokenSource();

            Task.Factory.StartNew(async () =>
                {
                    await ApiRequests.GetMJpegStreamAsync(
                        cameraRequest, 
                        cts.Token,
                        (buffer, length) => parser.BufferHandler(buffer, length));
                },
                streamMode == StreamMode.Streaming ? 
                    TaskCreationOptions.LongRunning :
                    TaskCreationOptions.None
            );
        }

        public void Stop()
        {
            isStarted = false;

            if (cts == null || cts.IsCancellationRequested)
                return;

            cts.Cancel();
        }

        public void Restart()
        {
            Stop();
            Start();
        }


        public void ChangeChannel(ChannelInfo channel)
        {
            if (channel == null)
                return;

            if (cameraRequest.Channel != channel)
            {
                cameraRequest.Channel = channel;

                if (isStarted)
                    Restart();
            }
        }

        public void ChangeResolution(ResolutionInfo resolution)
        {
            if (resolution == null)
                return;

            if (cameraRequest.Resolution != resolution)
            {
                cameraRequest.Resolution = resolution;

                if (isStarted)
                    Restart();
            }
        }


        public void Dispose()
        {
            Stop();
            parser.Dispose();
        }
    }
}
