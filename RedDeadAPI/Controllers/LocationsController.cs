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
	public class LocationsController : ControllerBase
	{
		public readonly LocationService _locationService;

		public LocationsController(LocationService locationService)
		{
			_locationService = locationService;
		}

		/// <summary>
		/// Gets all Locations.
		/// </summary>
		// GET: api/<locations>
		[AllowAnonymous]
		[HttpGet]
		public ActionResult<List<LocationDTO>> GetLocations() =>
			_locationService.Get();

		/// <summary>
		/// Gets all Locations from a specific game.
		/// </summary>
		[AllowAnonymous]
		[HttpGet("from/{game}")]
		public ActionResult<List<LocationDTO>> GetLocationsFromGame(string game) =>
			_locationService.GetFromGame(game);

		/// <summary>
		/// Gets a spcific Location.
		/// </summary>
		// GET api/<locations>/5
		[AllowAnonymous]
		[HttpGet("{id}")]
		public ActionResult<LocationDTO> GetLocation(string id)
		{
			var location = _locationService.Get(id);

			if (location == null)
			{
				return NotFound();
			}

			return location;
		}

		// POST api/<locations>
		[ApiExplorerSettings(IgnoreApi = true)]
		[HttpPost]
		public ActionResult<Location> PostLocation(Location location)
		{
			_locationService.Create(location);

			return CreatedAtRoute(nameof(GetLocation), new { id = location.Id }, location);
		}

		// PUT api/<locations>/5
		[ApiExplorerSettings(IgnoreApi = true)]
		[HttpPut("{id}")]
		public IActionResult PutLocation(string  id, Location locationIn)
		{
			var location = _locationService.Get(id);

			if (location == null)
			{
				return NotFound();
			}

			_locationService.Update(id, locationIn);

			return NoContent();
		}

		// DELETE api/<locations>/5
		[ApiExplorerSettings(IgnoreApi = true)]
		[HttpDelete("{id}")]
		public IActionResult DeleteLocation(string id)
		{
			var location = _locationService.Get(id);

			if (location == null)
			{
				return NotFound();
			}

			_locationService.Remove(id);

			return NoContent();
		}
	}
}
