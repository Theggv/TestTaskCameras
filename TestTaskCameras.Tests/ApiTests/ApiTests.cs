using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestTaskCameras.Models.Api;

namespace TestTaskCameras.Tests.ApiTests
{
    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public async Task GetConfigurationTest()
        {
            var resp = await ApiRequests.GetConfigurationAsync();

            Assert.IsNotNull(resp?.Channels);
            Assert.IsNotNull(resp?.Servers);
            Assert.IsNotNull(resp?.MobileServerInfo);
        }

        [TestMethod]
        public async Task GetMjpegStreamTest()
        {
            var cts = new CancellationTokenSource();
            var parser = new MJpegStreamParser();

            await ApiRequests.GetMJpegStreamAsync(cts.Token, (buffer, len) => parser.BufferHandler(buffer, len));
        }
    }
}
