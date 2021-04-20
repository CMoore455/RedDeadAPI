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
	public class GamesController : ControllerBase
	{
		public readonly GameService _gameService;

		public GamesController(GameService gameService)
		{
			_gameService = gameService; 
		}

		/// <summary>
		/// Gets all Games.
		/// </summary>
		/// <returns>A list of Games</returns>
		// GET: api/<games>
		[AllowAnonymous]
		[HttpGet]
		public ActionResult<List<GameDTO>> GetGames() =>
			_gameService.Get();

		/// <summary>
		/// Gets a specific Game.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>A a specific Game</returns>
		// GET api/<games>/5
		[AllowAnonymous]
		[HttpGet("{id}")]
		public ActionResult<GameDTO> GetGame(string id)
		{
			var game = _gameService.Get(id);

			if (game == null)
			{
				return NotFound();
			}

			return game;
		}

		// POST api/<games>
		[ApiExplorerSettings(IgnoreApi = true)]
		[HttpPost]   
		public ActionResult<Game> PostGame(Game Game)
		{
			_gameService.Create(Game);

			return CreatedAtRoute(nameof(GetGame), new { id = Game.Id }, Game);
		}

		// PUT api/<games>/5
		[ApiExplorerSettings(IgnoreApi = true)]
		[HttpPut("{id}")]
		public IActionResult PutGame(string  id, Game gameIn)
		{
			var game = _gameService.Get(id);

			if (game == null)
			{
				return NotFound();
			}

			_gameService.Update(id, gameIn);

			return NoContent();
		}

		// DELETE api/<games>/5
		[ApiExplorerSettings(IgnoreApi = true)]
		[HttpDelete("{id}")]
		public IActionResult DeleteGame(string id)
		{
			var game = _gameService.Get(id);

			if (game == null)
			{
				return NotFound();
			}

			_gameService.Remove(id);

			return NoContent();
		}

	}
}
