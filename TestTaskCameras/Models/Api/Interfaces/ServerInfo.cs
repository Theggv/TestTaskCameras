using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestTaskCameras.Models.Api.Interfaces
{
	[XmlRoot("ServerInfo")]
	public class ServerInfo
	{
		[XmlAttribute(AttributeName = "Id")]
		public string Id { get; set; }

		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "Url")]
		public string Url { get; set; }
	}
}
