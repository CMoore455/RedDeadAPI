using MongoDB.Driver;
using RedDeadAPI.Interfaces;
using RedDeadAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RedDeadAPI.Services
{
	public class LocationService
	{
		private readonly IMongoCollection<Location> _locations;

		public LocationService(IRedDeadAPIDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_locations = database.GetCollection<Location>(settings.LocationsCollectionName);
		}

		public List<LocationDTO> Get() =>
			_locations.AsQueryable().LocationToDTO().ToList();

		public LocationDTO Get(string id) =>
			LocationToDTO(_locations.Find(location => location.Id == id).FirstOrDefault());

		public Location Create(Location location)
		{
			_locations.InsertOne(location);
			return location;
		}

		public List<LocationDTO> GetFromGame(string game)
		{
			List<LocationDTO> result = null;
			var queryableItems = _locations.AsQueryable();
			switch (game)
			{
				case "redemption":
					var query1 = 
					result = queryableItems
						.Where(location => location.Games.Any(game => game.Contains("games/1")))
						.LocationToDTO()
						.ToList();
					break;
				case "redemption2":
					result = queryableItems
						.Where(location => location.Games.Any(game => game.Contains("games/2")))
						.LocationToDTO()
						.ToList();
					break;
				case "revolver":
					result = queryableItems
						.Where(location => location.Games.Any(game => game.Contains("games/3")))
						.LocationToDTO()
						.ToList(); 
					break;
				default:
					result = null;
					break;
			}
			return result;
		}

		public void Update(string id, Location locationIn) =>
			_locations.ReplaceOne(location => location.Id == id, locationIn);

		public void Remove(Location locationIn) =>
			_locations.DeleteOne(location => location.Id == locationIn.Id);

		public void Remove(string id) =>
			_locations.DeleteOne(location => location.Id == id);

		private static LocationDTO LocationToDTO(Location location)
		{
			return new LocationDTO
			{
				Name = location.Name,
				Games = location.Games,
				Type = location.Type,
				StateTerritory = location.StateTerritory,
				Region = location.Region,
				Inhabitants = location.Inhabitants,
				Description = location.Description
			};
		}
	}
}
