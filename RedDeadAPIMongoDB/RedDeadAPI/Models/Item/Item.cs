using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RedDeadAPI.Models
{
	public class Item
	{
		[BsonId]
		public string Id { get; set; }
		public string Name { get; set; }
		public string Game { get; set; }
		public string Type { get; set; }
		public string Price { get; set; }
		public string CostToSell { get; set; }
		public string Description { get; set; }
	}
}
