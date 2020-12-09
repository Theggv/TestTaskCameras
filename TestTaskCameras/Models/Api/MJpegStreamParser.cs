using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace TestTaskCameras.Models.Api
{
    public class MJpegStreamParser : IDisposable
    {
        public event EventHandler<BitmapFrame> OnImageReady;

        private bool isStartFound;
        private MemoryStream memoryStream;

        private byte currentByte;
        private byte previousByte;

        public MJpegStreamParser()
        {
            isStartFound = false;
            memoryStream = new MemoryStream();
            previousByte = 0;
        }

        /*
         *  Idea of algorithm:
         *      1) Find start
         *      2) 
         */
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
                        ParseImage();
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

        public void ParseImage()
        {
            try
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                var decoder = new JpegBitmapDecoder(memoryStream, BitmapCreateOptions.None, BitmapCacheOption.Default);
                var bitmapSource = decoder.Frames[0];

                if(bitmapSource.CanFreeze)
                    bitmapSource.Freeze();

                OnImageReady?.Invoke(this, bitmapSource);
            }
            catch(Exception e)
            {
                // ignore errors
            }

            memoryStream.Position = 0;
            memoryStream.SetLength(0);
        }

        public void Dispose()
        {
            memoryStream.Close();
        }
    }
}
