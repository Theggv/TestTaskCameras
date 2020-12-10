using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestTaskCameras.Models.Api.Interfaces
{
	[XmlRoot("ChannelInfo")]
	public class ChannelInfo: IEquatable<ChannelInfo>
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
		public bool IsDisabled { get; set; }

		[XmlAttribute("IsSoundOn")]
		public bool IsSoundOn { get; set; }

		[XmlAttribute("IsArchivingEnabled")]
		public bool IsArchivingEnabled { get; set; }

		[XmlAttribute("IsSoundArchivingEnabled")]
		public bool IsSoundArchivingEnabled { get; set; }

		[XmlAttribute("AllowedRealtime")]
		public bool AllowedRealtime { get; set; }

		[XmlAttribute("AllowedArchive")]
		public bool AllowedArchive { get; set; }

		[XmlAttribute("IsPtzOn")]
		public bool IsPtzOn { get; set; }

		[XmlAttribute("IsTransmitSoundOn")]
		public bool IsTransmitSoundOn { get; set; }

		[XmlAttribute("ArchiveMode")]
		public string ArchiveMode { get; set; }

		[XmlAttribute("ArchiveStreamType")]
		public string ArchiveStreamType { get; set; }

		[XmlAttribute("IsFaceAnalystEnabled")]
		public bool IsFaceAnalystEnabled { get; set; }


        public bool Equals(ChannelInfo other)
        {
			return Id == other.Id;
        }
    }
}
