using MongoDB.Driver;
using MongoDB.Driver.Linq;
using RedDeadAPI.Interfaces;
using RedDeadAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDeadAPI.Services
{
	public class ItemService
	{
		private readonly IMongoCollection<Item> _items;

		public ItemService(IRedDeadAPIDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_items = database.GetCollection<Item>(settings.ItemsCollectionName);
		}

		public List<ItemDTO> Get() =>
			_items.AsQueryable().ItemToDTO().ToList();

		public ItemDTO Get(string id) =>
			ItemToDTO(_items.Find(item => item.Id == id).FirstOrDefault());

		public List<ItemDTO> GetFromGame(string game)
		{
			List<ItemDTO> result = null;
			var queryableItems = _items.AsQueryable();

			switch (game)
			{
				case "redemption":
					result = queryableItems
						.Where(item => item.Game.Contains("Games/1"))
						.ItemToDTO()
						.ToList(); ;
					break;
				case "redemption2":
					result = queryableItems
						.Where(item => item.Game.Contains("Games/2"))
						.ItemToDTO()
						.ToList();
					break;
				case "revolver":
					result = queryableItems
						.Where(item => item.Game.Contains("Games/3"))
						.ItemToDTO()
						.ToList(); ;
					break;
				default:
					result = null;
					break;
			}
			return result;
		}

		public Item Create(Item item)
		{
			_items.InsertOne(item);
			return item;
		}

		public void Update(string id, Item itemIn) =>
			_items.ReplaceOne(item => item.Id == id, itemIn);

		public void Remove(Item itemIn) =>
			_items.DeleteOne(item => item.Id == itemIn.Id);

		public void Remove(string id) =>
			_items.DeleteOne(item => item.Id == id);

		private static ItemDTO ItemToDTO(Item item)
		{
			return new ItemDTO
			{
				Name = item.Name,
				Type = item.Type,
				Price = item.Price,
				Game = item.Game,
				CostToSell = item.CostToSell,
				Description = item.Description
			};
		}
	}
}
