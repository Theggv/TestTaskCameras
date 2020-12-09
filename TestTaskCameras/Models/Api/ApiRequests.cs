using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using TestTaskCameras.Models.Api.Interfaces;

namespace TestTaskCameras.Models.Api
{
    public static class ApiRequests
    {
        public static async Task<Configuration> GetConfigurationAsync()
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
                        var xmlSerializer = new XmlSerializer(typeof(Configuration));
                        return (Configuration)xmlSerializer.Deserialize(reader);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public static async Task GetMJpegStreamAsync(CancellationToken token, Action<byte[], int> action, int maxChunkSize = 1024)
        {
            var url = "http://demo.macroscop.com:8080/mobile?login=root&channelid=2016897c-8be5-4a80-b1a3-7f79a9ec729c&resolutionX=640&resolutionY=480&fps=25";
            
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
