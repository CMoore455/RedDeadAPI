using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDeadAPI.Models
{
	public class WeaponDTO
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public string Game { get; set; }
		public string Power { get; set; }
		public string Range { get; set; }
		public string RateOfFire { get; set; }
		public string ReloadSpeed { get; set; }
		public string AmmoCapacity { get; set; }
		public string AmmoMax { get; set; }
		public string AmmoType { get; set; }
		public string Accuracy { get; set; }
		public string BasePrice { get; set; }
		public string Description { get; set; }
	}
}
