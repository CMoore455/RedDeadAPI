using MongoDB.Driver;
using RedDeadAPI.Interfaces;
using RedDeadAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDeadAPI.Services
{
	public class MountService
	{
		private readonly IMongoCollection<Mount> _mounts;

		public MountService(IRedDeadAPIDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_mounts = database.GetCollection<Mount>(settings.MountsCollectionName);
		}

		public List<MountDTO> Get() =>
			_mounts.AsQueryable().MountToDTO().ToList();

		public MountDTO Get(string id) =>
			MountToDTO(_mounts.Find(mount => mount.Id == id).FirstOrDefault());

		public Mount Create(Mount mount)
		{
			_mounts.InsertOne(mount);
			return mount;
		}

		public List<MountDTO> GetFromGame(string game)
		{
			List<MountDTO> result = null;
			var queryableItems = _mounts.AsQueryable();

			switch (game)
			{
				case "redemption":
					result = queryableItems
						.Where(mount => mount.Game.Contains("Games/1"))
						.MountToDTO()
						.ToList(); ;
					break;
				case "redemption2":
					result = queryableItems
						.Where(mount => mount.Game.Contains("Games/2"))
						.MountToDTO()
						.ToList();
					break;
				case "revolver":
					result = queryableItems
						.Where(mount => mount.Game.Contains("Games/3"))
						.MountToDTO()
						.ToList(); ;
					break;
				default:
					result = null;
					break;
			}
			return result;
		}

		public void Update(string id, Mount gameIn) =>
			_mounts.ReplaceOne(mount => mount.Id == id, gameIn);

		public void Remove(Mount gameIn) =>
			_mounts.DeleteOne(mount => mount.Id == gameIn.Id);

		public void Remove(string id) =>
			_mounts.DeleteOne(mount => mount.Id == id);

		private static MountDTO MountToDTO(Mount mount)
		{
			return new MountDTO
			{
				Name = mount.Name,
				Breed = mount.Breed,
				Game = mount.Game,
				Category = mount.Category,
				Handling = mount.Handling,
				Color = mount.Color,
				Speed = mount.Speed,
				Health = mount.Health,
				Stamina = mount.Stamina,
				Location = mount.Location,
				BasePrice = mount.BasePrice,
				Description = mount.Description
			};
		}
	}
}
