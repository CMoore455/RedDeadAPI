using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedDeadAPI.Models;
using RedDeadAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDeadAPI.Controllers
{
	[Produces("application/json")]
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class PeopleController : ControllerBase
	{
		public readonly PersonService _peopleService;

		public PeopleController(PersonService personService)
		{
			_peopleService = personService;
		}

		/// <summary>
		/// Gets all People.
		/// </summary>
		// GET: api/<people>
		[AllowAnonymous]
		[HttpGet]
		public ActionResult<List<PersonDTO>> GetPeople() =>
			_peopleService.Get();

		/// <summary>
		/// Gets all People from a specific game.
		/// </summary>
		// GET api/<people>/5
		[AllowAnonymous]
		[HttpGet("{id}")]
		public ActionResult<PersonDTO> GetPerson(string id)
		{
			var person = _peopleService.Get(id);

			if (person == null)
			{
				return NotFound();
			}

			return person;
		}

		/// <summary>
		/// Gets a specific Person.
		/// </summary>
		// GET api/<people>/from/game
		[AllowAnonymous]
		[HttpGet("from/{game}")]
		public ActionResult<List<PersonDTO>> GetPeopleFromGame(string game) =>
			_peopleService.GetFromGame(game);

		// POST api/<people>
		[ApiExplorerSettings(IgnoreApi = true)]
		[HttpPost]
		public ActionResult<Person> PostPerson(Person Person)
		{
			_peopleService.Create(Person);

			return CreatedAtRoute(nameof(GetPerson), new { id = Person.Id }, Person);
		}

		// PUT api/<people>/5
		[ApiExplorerSettings(IgnoreApi = true)]
		[HttpPut("{id}")]
		public IActionResult PutPerson(string id, Person personIn)
		{
			var person = _peopleService.Get(id);

			if (person == null)
			{
				return NotFound();
			}

			_peopleService.Update(id, personIn);

			return NoContent();
		}

		// DELETE api/<people>/5
		[ApiExplorerSettings(IgnoreApi = true)]
		[HttpDelete("{id}")]
		public IActionResult DeletePerson(string id)
		{
			var person = _peopleService.Get(id);

			if (person == null)
			{
				return NotFound();
			}

			_peopleService.Remove(id);

			return NoContent();
		}
	}
}
