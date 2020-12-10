using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Serialization;
using TestTaskCameras.Models.Api.Interfaces;

namespace TestTaskCameras.Models.Api
{
    public static class ApiRequests
    {
        public static async Task<ChannelConfiguration> GetConfigurationAsync()
        {
            var url = "http://demo.macroscop.com:8080/configex?login=root";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(url);
                    var content = await response.Content.ReadAsStringAsync();

                    using (var reader = new StringReader(content))
                    {
                        var xmlSerializer = new XmlSerializer(typeof(ChannelConfiguration));
                        return (ChannelConfiguration)xmlSerializer.Deserialize(reader);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public static async Task GetMJpegStreamAsync(CameraRequest request, CancellationToken token, Action<byte[], int> action)
        {
            if (request.Channel is null)
                throw new ArgumentException("request.Channel can not be null.");

            var maxChunkSize = 1024;

            var baseUrl = "http://demo.macroscop.com:8080";
            var endPoint = $"/mobile?login=root" +
                $"&channelid={request.Channel.Id}" +
                $"&resolutionX={request.Resolution?.Width ?? 640}" +
                $"&resolutionY={request.Resolution?.Height ?? 480}" +
                $"&fps=25";

            var url = baseUrl + endPoint;

            using (var client = new HttpClient())
            {
                using(var stream = await client.GetStreamAsync(url))
                {
                    var buffer = new byte[maxChunkSize];

                    while (!token.IsCancellationRequested)
                    {
                        var streamLength = await stream.ReadAsync(buffer, 0, maxChunkSize, token);
                        action(buffer, streamLength);
                    }
                }
            }
        }
    }
}
