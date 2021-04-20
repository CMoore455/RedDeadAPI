using RedDeadAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDeadAPI
{
	public static class Extentions
	{
		public static IQueryable<ItemDTO> ItemToDTO(this IQueryable<Item> items)
		{
			return items.Select(item => new ItemDTO
			{
				Name = item.Name,
				Type = item.Type,
				Price = item.Price,
				Game = item.Game,
				CostToSell = item.CostToSell,
				Description = item.Description
			});
		}

		public static IQueryable<GameDTO> GameToDTO(this IQueryable<Game> games)
		{
			return games.Select(game => new GameDTO
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
			});
		}
		public static IQueryable<WeaponDTO> WeaponToDTO(this IQueryable<Weapon> weapons)
		{
			return weapons.Select(weapon => new WeaponDTO
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
			});
		}

		public static IQueryable<MountDTO> MountToDTO(this IQueryable<Mount> mounts)
		{
			return mounts.Select(mount => new MountDTO
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
			});
		}

		public static IQueryable<PersonDTO> PersonToDTO(this IQueryable<Person> people)
		{
			return people.Select(person => new PersonDTO
			{
				Name = person.Name,
				Game = person.Game,
				Nationality = person.Nationality,
				Gender = person.Gender,
				Locations = person.Locations,
				Family = person.Family,
				Occupation = person.Occupation,
				Weapon = person.Weapon,
				Mount = person.Mount
			});
		}

		public static IQueryable<LocationDTO> LocationToDTO(this IQueryable<Location> location)
		{
			return location.Select(location => new LocationDTO
			{
				Name = location.Name,
				Games = location.Games,
				Type = location.Type,
				StateTerritory = location.StateTerritory,
				Region = location.Region,
				Inhabitants = location.Inhabitants,
				Description = location.Description
			});
		}

		public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
		{
			return users.Select(x => x.WithoutPassword());
		}

		public static User WithoutPassword(this User user)
		{
			user.Password = null;
			return user;
		}
	}
}
