using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestTaskCameras.Models.Api.Interfaces
{
	[XmlRoot("MobileServerInfo")]
	public class MobileServerInfo
	{
		[XmlArray("Resolutions")]
		[XmlArrayItem("ResolutionInfo")]
		public List<ResolutionInfo> Resolutions { get; set; }

		[XmlAttribute("IsEnabled")]
		public bool IsEnabled { get; set; }

		[XmlAttribute("IsProxyEnabled")]
		public bool IsProxyEnabled { get; set; }

		[XmlAttribute("IsMobilePushEnabled")]
		public bool IsMobilePushEnabled { get; set; }

		[XmlAttribute("Port")]
		public int Port { get; set; }

		[XmlAttribute("UsePFrames")]
		public bool UsePFrames { get; set; }

		[XmlAttribute("FpsLimit")]
		public string FpsLimit { get; set; }

		[XmlAttribute("LowResolution")]
		public string LowResolution { get; set; }

		[XmlAttribute("MiddleResolution")]
		public string MiddleResolution { get; set; }

		[XmlAttribute("HighResolution")]
		public string HighResolution { get; set; }
	}
}
