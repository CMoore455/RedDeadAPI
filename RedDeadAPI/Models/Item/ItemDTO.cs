using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDeadAPI.Models
{
	public class ItemDTO
	{
		public string Name { get; set; }
		public string Game { get; set; }
		public string Type { get; set; }
		public string Price { get; set; }
		public string CostToSell { get; set; }
		public string Description { get; set; }
	}
}
