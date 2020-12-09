using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestTaskCameras.Models.Api.Interfaces
{
	[XmlRoot("ResolutionInfo")]
	public class ResolutionInfo
	{
		[XmlAttribute("Width")]
		public string Width { get; set; }

		[XmlAttribute("Height")]
		public string Height { get; set; }

		[XmlAttribute("IsEnabled")]
		public string IsEnabled { get; set; }

		[XmlAttribute("FpsLimit")]
		public string FpsLimit { get; set; }

		[XmlAttribute("UsePFrames")]
		public string UsePFrames { get; set; }

		[XmlAttribute("Type")]
		public string Type { get; set; }
	}
}
