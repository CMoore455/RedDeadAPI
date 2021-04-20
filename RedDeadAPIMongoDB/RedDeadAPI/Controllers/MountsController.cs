using Microsoft.AspNetCore.Http;
using RedDeadAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedDeadAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace RedDeadAPI.Controllers
{
	[Produces("application/json")]
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class MountsController : ControllerBase
	{
		public readonly MountService _mountService;

		public MountsController(MountService mountService)
		{
			_mountService = mountService;
		}

		/// <summary>
		/// Gets all Mounts.
		/// </summary>
		// GET: api/<mounts>
		[AllowAnonymous]
		[HttpGet]
		public ActionResult<List<MountDTO>> GetMounts() =>
			_mountService.Get();

		/// <summary>
		/// Gets all Mounts from a specific game.
		/// </summary>
		[AllowAnonymous]
		[HttpGet("from/{game}")]
		public ActionResult<List<MountDTO>> GetMountsFromGame(string game) =>
			_mountService.GetFromGame(game);

		/// <summary>
		/// Gets a specific Mount.
		/// </summary>
		// GET api/<mounts>/5
		[AllowAnonymous]
		[HttpGet("{id}")]
		public ActionResult<MountDTO> GetMount(string id)
		{
			var mount = _mountService.Get(id);

			if (mount == null)
			{
				return NotFound();
			}

			return mount;
		}

		// POST api/<mounts>
		[ApiExplorerSettings(IgnoreApi = true)]
		[HttpPost]
		public ActionResult<Mount> PostMount(Mount mount)
		{
			_mountService.Create(mount);

			return CreatedAtRoute(nameof(GetMount), new { id = mount.Id }, mount);
		}

		// PUT api/<mounts>/5
		[ApiExplorerSettings(IgnoreApi = true)]
		[HttpPut("{id}")]
		public IActionResult PutMount(string id, Mount itemIn)
		{
			var mount = _mountService.Get(id);

			if (mount == null)
			{
				return NotFound();
			}

			_mountService.Update(id, itemIn);

			return NoContent();
		}

		// DELETE api/<mounts>/5
		[ApiExplorerSettings(IgnoreApi = true)]
		[HttpDelete("{id}")]
		public IActionResult DeleteMount(string id)
		{
			var mount = _mountService.Get(id);

			if (mount == null)
			{
				return NotFound();
			}

			_mountService.Remove(id);

			return NoContent();
		}
	}
}
