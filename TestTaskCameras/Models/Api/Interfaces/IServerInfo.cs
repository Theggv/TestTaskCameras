using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskCameras.Models.Api.Interfaces
{
    interface IServerInfo
    {
        string Id { get; }

        string Name { get; }

        string Url { get; }
    }
}
