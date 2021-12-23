using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicTacToe.Models.ViewModels;
using TicTacToe.Services.Interfaces;

namespace TicTacToe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        private readonly IGameService _gameService;

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
            //TODO verify that start player is one of the players
            var result = await _gameService.Create(data);
            return Ok(result);
        }

    }
}

