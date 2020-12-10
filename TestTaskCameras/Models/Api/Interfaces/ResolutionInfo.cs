using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestTaskCameras.Models.Api.Interfaces
{
	[XmlRoot("ResolutionInfo")]
	public class ResolutionInfo: IEquatable<ResolutionInfo>
	{
		[XmlAttribute("Width")]
		public int Width { get; set; }

		[XmlAttribute("Height")]
		public int Height { get; set; }

		[XmlAttribute("IsEnabled")]
		public bool IsEnabled { get; set; }

		[XmlAttribute("FpsLimit")]
		public string FpsLimit { get; set; }

		[XmlAttribute("UsePFrames")]
		public bool UsePFrames { get; set; }

		[XmlAttribute("Type")]
		public string Type { get; set; }


        public bool Equals(ResolutionInfo other)
        {
			return Type == other.Type;
        }
    }
}
