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
	public class ItemsController : ControllerBase
	{
		public readonly ItemService _itemService;

		public ItemsController(ItemService itemService)
		{
			_itemService = itemService;
		}

		/// <summary>
		/// Gets all Items.
		/// </summary>
		// GET: api/<items>
		[AllowAnonymous]
		[HttpGet]
		public ActionResult<List<ItemDTO>> GetItems() =>
			_itemService.Get();

		/// <summary>
		/// Gets all Items from a specific game.
		/// </summary>
		[AllowAnonymous]
		[HttpGet("from/{game}")]
		public ActionResult<List<ItemDTO>> GetItemsFromGame(string game) =>
			_itemService.GetFromGame(game);

		/// <summary>
		/// Gets a specific Item.
		/// </summary>
		// GET api/<items>/5
		[AllowAnonymous]
		[HttpGet("{id}")]
		public ActionResult<ItemDTO> GetItem(string id)
		{
			var item = _itemService.Get(id);

			if (item == null)
			{
				return NotFound();
			}

			return item;
		}

		// POST api/<items>
		[ApiExplorerSettings(IgnoreApi = true)]
		[HttpPost]
		public ActionResult<Item> PostItem(Item item)
		{
			_itemService.Create(item);

			return CreatedAtRoute(nameof(GetItem), new { id = item.Id }, item);
		}

		// PUT api/<items>/5
		[ApiExplorerSettings(IgnoreApi = true)]
		[HttpPut("{id}")]
		public IActionResult PutItem(string  id, Item itemIn)
		{
			var item = _itemService.Get(id);

			if (item == null)
			{
				return NotFound();
			}

			_itemService.Update(id, itemIn);

			return NoContent();
		}

		// DELETE api/<items>/5
		[ApiExplorerSettings(IgnoreApi = true)]
		[HttpDelete("{id}")]
		public IActionResult DeleteItem(string id)
		{
			var item = _itemService.Get(id);

			if (item == null)
			{
				return NotFound();
			}

			_itemService.Remove(id);

			return NoContent();
		}

	}
}
