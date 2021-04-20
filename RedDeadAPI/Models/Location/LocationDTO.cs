using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDeadAPI.Models
{
	public class LocationDTO
	{
		public string Name { get; set; }
		public string[] Games { get; set; }
		public string Type { get; set; }
		public string StateTerritory { get; set; }
		public string Region { get; set; }
		public string[] Inhabitants { get; set; }
		public string Description { get; set; }

	}
}
