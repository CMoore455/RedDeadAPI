using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDeadAPI.Models
{
	public class PersonDTO
	{
		public string Name { get; set; }
		public string[] Game { get; set; }
		public string Nationality { get; set; }
		public string Gender { get; set; }
		public string[] Locations { get; set; }
		public string[] Family { get; set; }
		public string[] Occupation { get; set; }
		public string[] Weapon { get; set; }
		public string[] Mount { get; set; }
	}
}
