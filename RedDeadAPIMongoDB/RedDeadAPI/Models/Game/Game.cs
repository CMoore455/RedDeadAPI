using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RedDeadAPI.Models
{
	public class Game
	{
		[BsonId]
		public string Id { get; set; }
		public string Title { get; set; }
		public string[] Developer { get; set; }
		public string Publisher { get; set; }
		public string[] ReleaseDate { get; set; }
		public string[] Genre { get; set; }
		public string[] Modes { get; set; }
		public string[] Rating { get; set; }
		public string[] Platforms { get; set; }
		public string[] Media { get; set; }
		public string Mounts { get; set; }
		public string Weapons { get; set; }
		public string Items { get; set; }
		public string Locations { get; set; }
	}
}
