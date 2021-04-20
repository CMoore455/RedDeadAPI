using RedDeadAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDeadAPI.Models
{
	public class RedDeadAPITestDatabaseSettings : IRedDeadAPIDatabaseSettings
	{
		public string ItemsCollectionName { get; set; }
		public string GamesCollectionName { get; set; }
		public string WeaponsCollectionName { get; set; }
		public string MountsCollectionName { get; set; }
		public string PeopleCollectionName { get; set; }
		public string LocationsCollectionName { get; set; }
		public string UsersCollectionName { get; set; }
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
	}
}
