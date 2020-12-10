using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestTaskCameras.Models.Api.Interfaces
{
	[XmlRoot("Configuration")]
	public class ChannelConfiguration
	{
		[XmlArray("Servers")]
		[XmlArrayItem("ServerInfo")]
		public List<ServerInfo> Servers { get; set; }

		[XmlArray("Channels")]
		[XmlArrayItem("ChannelInfo")]
		public List<ChannelInfo> Channels { get; set; }

		[XmlElement("MobileServerInfo")]
		public MobileServerInfo MobileServerInfo { get; set; }
	}
}
