using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskCameras.Models.Api
{
    class ApiRequests
    {
        static async Task GetConfiguration()
        {
            var url = "http://demo.macroscop.com:8080/configex?login=root";

            var request = WebRequest.CreateHttp(url);
        }
    }
}
