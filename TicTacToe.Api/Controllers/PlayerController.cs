using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicTacToe.Models.ViewModels;
using TicTacToe.Services.Interfaces;

namespace TicTacToe.Api.Controllers
{
    /// <summary>
    /// Endpoints for Player
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        /// <summary>
        /// Player Controller Constructor
        /// </summary>
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
 
        /// <summary>
        /// Create a new player
        /// </summary>
        [HttpPost]
            public async Task<ActionResult<PlayerVM>> Create([FromBody] PlayerCreateVM data)
            {
                var result = await _playerService.Create(data);
                return Ok(result);
            }

        }
}
