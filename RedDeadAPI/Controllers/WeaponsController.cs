using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedDeadAPI.Models;
using RedDeadAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RedDeadAPI.Controllers
{
	[Produces("application/json")]
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class WeaponsController : ControllerBase
	{
		public readonly WeaponService _weaponService;

		public WeaponsController(WeaponService weaponService)
		{
			_weaponService = weaponService;
		}

		/// <summary>
		/// Gets all Weapons.
		/// </summary>
		// GET: api/<weapons>
		[AllowAnonymous]
		[HttpGet]
		public ActionResult<List<WeaponDTO>> GetWeapons() =>
			_weaponService.Get();

		/// <summary>
		/// Gets a specific game.
		/// </summary>
		// GET api/<weapons>/5
		[AllowAnonymous]
		[HttpGet("{id}")]
		public ActionResult<WeaponDTO> GetWeapon(string id)
		{
			var weapon = _weaponService.Get(id);

			if (weapon == null)
			{
				return NotFound();
			}

			return weapon;
		}


		// POST api/<weapons>
		[ApiExplorerSettings(IgnoreApi = true)]
		[HttpPost]   
		public ActionResult<Weapon> PostWeapon(Weapon Weapon)
		{
			_weaponService.Create(Weapon);

			return CreatedAtRoute(nameof(GetWeapon), new { id = Weapon.Id }, Weapon);
		}

		// PUT api/<weapons>/5
		[ApiExplorerSettings(IgnoreApi = true)]
		[HttpPut("{id}")]
		public IActionResult PutWeapon(string  id, Weapon weaponIn)
		{
			var weapon = _weaponService.Get(id);

			if (weapon == null)
			{
				return NotFound();
			}

			_weaponService.Update(id, weaponIn);

			return NoContent();
		}

		// DELETE api/<weapsons>/5
		[ApiExplorerSettings(IgnoreApi = true)]
		[HttpDelete("{id}")]
		public IActionResult DeleteWeapon(string id)
		{
			var weapon = _weaponService.Get(id);

			if (weapon == null)
			{
				return NotFound();
			}

			_weaponService.Remove(id);

			return NoContent();
		}

	}
}
