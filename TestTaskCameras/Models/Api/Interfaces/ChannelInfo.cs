using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestTaskCameras.Models.Api.Interfaces
{
	[XmlRoot(ElementName = "ChannelInfo")]
	public class ChannelInfo
	{
		[XmlAttribute("Id")]
		public string Id { get; set; }

		[XmlAttribute("Name")]
		public string Name { get; set; }

		[XmlAttribute("Description")]
		public string Description { get; set; }

		[XmlAttribute("DeviceInfo")]
		public string DeviceInfo { get; set; }

		[XmlAttribute("AttachedToServer")]
		public string AttachedToServer { get; set; }

		[XmlAttribute("IsDisabled")]
		public string IsDisabled { get; set; }

		[XmlAttribute("IsSoundOn")]
		public string IsSoundOn { get; set; }

		[XmlAttribute("IsArchivingEnabled")]
		public string IsArchivingEnabled { get; set; }

		[XmlAttribute("IsSoundArchivingEnabled")]
		public string IsSoundArchivingEnabled { get; set; }

		[XmlAttribute("AllowedRealtime")]
		public string AllowedRealtime { get; set; }

		[XmlAttribute("AllowedArchive")]
		public string AllowedArchive { get; set; }

		[XmlAttribute("IsPtzOn")]
		public string IsPtzOn { get; set; }

		[XmlAttribute("IsTransmitSoundOn")]
		public string IsTransmitSoundOn { get; set; }

		[XmlAttribute("ArchiveMode")]
		public string ArchiveMode { get; set; }

		[XmlAttribute("ArchiveStreamType")]
		public string ArchiveStreamType { get; set; }

		[XmlAttribute("IsFaceAnalystEnabled")]
		public string IsFaceAnalystEnabled { get; set; }
	}
}
