using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.Models.ViewModels;
using TicTacToe.Services.Interfaces;

namespace TicTacToe.Api.Controllers
{
    /// <summary>
    /// Game Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        private readonly IGameService _gameService;

        /// <summary>
        /// Endpoints for Game Controller
        /// </summary>
        /// <param name="gameService"></param>
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        /// <summary>
        /// Create a new game
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<GameVM>> Create([FromBody] GameCreateVM data)
        {
            //verify that there are only 2 players
            if (data.PlayerIds.Count != 2) return BadRequest(new { message = "2 players are required" });
            //verify that start player is one of the players
            if (data.StartPlayer != data.PlayerIds[0] && data.StartPlayer != data.PlayerIds[1])
            {
                return BadRequest(new { message = "start player must be one of game players" });
            }
            var result = await _gameService.Create(data);
            return Ok(result);
        }


        /// <summary>
        /// place a move on a gameboard
        /// for the player whose turn it is
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("move")]
        public async Task<ActionResult<MoveVM>> Move([FromBody] MoveCreateVM data)
        {
            var result = await _gameService.Move(data);
            return Ok(result);
        }


        /// <summary>
        /// Current Games in progress
        /// moves registered and players
        /// pageIndex-start with pageIndex=1
        /// pageSize-how many users to display on a page
        /// </summary>
        [HttpGet]
        [Route("inprogress")]
        public async Task<ActionResult<List<GameInProgressVM>>> GetAllInProgress([FromQuery] int pageIndex, int pageSize)
        {
            var result = await _gameService.GetAllInProgress(pageIndex, pageSize);
            return Ok(result);
        }

    }
}

