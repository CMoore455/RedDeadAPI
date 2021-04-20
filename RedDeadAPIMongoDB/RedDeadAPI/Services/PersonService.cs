using MongoDB.Driver;
using RedDeadAPI.Interfaces;
using RedDeadAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDeadAPI.Services
{
	public class PersonService
	{
		private readonly IMongoCollection<Person> _people;

		public PersonService(IRedDeadAPIDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_people = database.GetCollection<Person>(settings.PeopleCollectionName);
		}

		public List<PersonDTO> Get() =>
			_people.AsQueryable().PersonToDTO().ToList();

		public PersonDTO Get(string id) =>
			PersonToDTO(_people.Find(person => person.Id == id).FirstOrDefault());

		public List<PersonDTO> GetFromGame(string game)
		{
			List<PersonDTO> result = null;
			var queryableItems = _people.AsQueryable();

			switch (game)
			{
				case "redemption":
					result = queryableItems
						.Where(person => person.Game.Contains("Games/1"))
						.PersonToDTO()
						.ToList(); ;
					break;
				case "redemption2":
					result = queryableItems
						.Where(person => person.Game.Contains("Games/2"))
						.PersonToDTO()
						.ToList();
					break;
				case "revolver":
					result = queryableItems
						.Where(person => person.Game.Contains("Games/3"))
						.PersonToDTO()
						.ToList(); ;
					break;
				default:
					result = null;
					break;
			}
			return result;
		}

		public Person Create(Person person)
		{
			_people.InsertOne(person);
			return person;
		}

		public void Update(string id, Person personIn) =>
			_people.ReplaceOne(person => person.Id == id, personIn);

		public void Remove(Person personIn) =>
			_people.DeleteOne(person => person.Id == personIn.Id);

		public void Remove(string id) =>
			_people.DeleteOne(person => person.Id == id);

		private static PersonDTO PersonToDTO(Person person)
		{
			return new PersonDTO
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
			};
		}
	}
}
