using MongoDB.Driver;
using RedDeadAPI.Interfaces;
using RedDeadAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDeadAPI.Services
{
	public class GameService
	{
		private readonly IMongoCollection<Game> _games;

		public GameService(IRedDeadAPIDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_games = database.GetCollection<Game>(settings.GamesCollectionName);
		}

		public List<GameDTO> Get() =>
			_games.AsQueryable().GameToDTO().ToList();

		public GameDTO Get(string id) =>
			GameToDTO(_games.Find(game => game.Id == id).FirstOrDefault());

		public Game Create(Game game)
		{
			_games.InsertOne(game);
			return game;
		}

		public void Update(string id, Game gameIn) =>
			_games.ReplaceOne(game => game.Id == id, gameIn);

		public void Remove(Game gameIn) =>
			_games.DeleteOne(game => game.Id == gameIn.Id);

		public void Remove(string id) =>
			_games.DeleteOne(game => game.Id == id);

		private static GameDTO GameToDTO(Game game)
		{
			return new GameDTO
			{
				Title = game.Title,
				Developer = game.Developer,
				Publisher = game.Publisher,
				ReleaseDate = game.ReleaseDate,
				Genre = game.Genre,
				Modes = game.Modes,
				Rating = game.Rating,
				Platforms = game.Platforms,
				Media = game.Media,
				Mounts = game.Mounts,
				Weapons = game.Weapons,
				Items = game.Items,
				Locations = game.Locations
			};
		}
	}
}
