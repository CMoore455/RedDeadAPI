using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDeadAPI.Interfaces
{
	public interface IRedDeadAPIDatabaseSettings
	{
		string ItemsCollectionName { get; set; }
		string GamesCollectionName { get; set; }
		string WeaponsCollectionName { get; set; }
		string MountsCollectionName { get; set; }
		string PeopleCollectionName { get; set; }
		string LocationsCollectionName { get; set; }
		string UsersCollectionName { get; set; }


		string ConnectionString { get; set; }
		string DatabaseName { get; set; }
	}
}
