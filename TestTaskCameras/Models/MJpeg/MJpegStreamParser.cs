using System;
using System.IO;

namespace TestTaskCameras.Models.MJpeg
{
    public class MJpegStreamParser : IDisposable
    {
        public event EventHandler<FrameReadyEventArgs> OnFrameReady;


        private bool isStartFound = false;
        private MemoryStream memoryStream;

        private byte currentByte;
        private byte previousByte;


        public MJpegStreamParser() 
        {
            memoryStream = new MemoryStream();
        }


        public void BufferHandler(byte[] buffer, int length, int startIndex = 0)
        {
            var index = startIndex;

            if (!isStartFound)
            {
                while (index < length)
                {
                    currentByte = buffer[index];

                    // SOI (start of image) - header that uses FF D8 as marker of start
                    if (previousByte == 0xff && currentByte == 0xd8)
                    {
                        isStartFound = true;

                        BufferHandler(buffer, length, index - 1);
                        return;
                    }

                    previousByte = buffer[index++];
                }
            }
            else
            {
                while (index < length)
                {
                    currentByte = buffer[index];

                    // EOI (end of image) - header that uses FF D9 as marker of end
                    if (previousByte == 0xff && currentByte == 0xd9)
                    {
                        isStartFound = false;
                        memoryStream.Write(buffer, startIndex, index - startIndex + 1);
                        SendFrame();
                    }
                    else if (index == length - 1)
                    {
                        // Write buffer to stream if end wasn't found
                        memoryStream.Write(buffer, startIndex, length - startIndex);
                    }

                    previousByte = buffer[index++];
                }
            }
        }

        public void SendFrame()
        {
            memoryStream.Seek(0, SeekOrigin.Begin);

            OnFrameReady?.Invoke(this, new FrameReadyEventArgs
            {
                Frame = memoryStream.ToArray()
            });

            memoryStream.Position = 0;
            memoryStream.SetLength(0);
        }

        public void Dispose()
        {
            memoryStream.Close();
        }
    }
}
