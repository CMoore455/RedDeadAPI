using MongoDB.Driver;
using RedDeadAPI.Interfaces;
using RedDeadAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDeadAPI.Services
{
	public class WeaponService
	{
		private readonly IMongoCollection<Weapon> _weapons;

		public WeaponService(IRedDeadAPIDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_weapons = database.GetCollection<Weapon>(settings.WeaponsCollectionName);
		}

		public List<WeaponDTO> Get() =>
			_weapons.AsQueryable().WeaponToDTO().ToList();

		public WeaponDTO Get(string id) =>
			WeaponToDTO(_weapons.Find(weapon => weapon.Id == id).FirstOrDefault());

		public Weapon Create(Weapon weapon)
		{
			_weapons.InsertOne(weapon);
			return weapon;
		}

		public void Update(string id, Weapon gameIn) =>
			_weapons.ReplaceOne(weapon => weapon.Id == id, gameIn);

		public void Remove(Weapon gameIn) =>
			_weapons.DeleteOne(weapon => weapon.Id == gameIn.Id);

		public void Remove(string id) =>
			_weapons.DeleteOne(weapon => weapon.Id == id);

		private static WeaponDTO WeaponToDTO(Weapon weapon)
		{
			return new WeaponDTO
			{
				Name = weapon.Name,
				Type = weapon.Type,
				Game = weapon.Game,
				Power = weapon.Power,
				Range = weapon.Range,
				RateOfFire = weapon.RateOfFire,
				ReloadSpeed = weapon.ReloadSpeed,
				AmmoCapacity = weapon.AmmoCapacity,
				AmmoMax = weapon.AmmoMax,
				AmmoType = weapon.AmmoType,
				Accuracy = weapon.Accuracy,
				BasePrice = weapon.BasePrice,
				Description = weapon.Description
			};
		}
	}
}
