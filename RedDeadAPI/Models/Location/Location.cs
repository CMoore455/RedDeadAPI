using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDeadAPI.Models
{
	public class Location
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string[] Games { get; set; }
		public string Type { get; set; }
		public string StateTerritory { get; set; }
		public string Region { get; set; }
		public string[] Inhabitants { get; set; }
		public string  Description { get; set; }
	}
}
