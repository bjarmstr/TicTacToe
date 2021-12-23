using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities;
using TicTacToe.Models.ViewModels;
using TicTacToe.Repositories.Repositories.Interfaces;
using TicTacToe.Services.Interfaces;

namespace TicTacToe.Services
{
    public class GameService: IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;

        public GameService(IGameRepository gameRepository, IPlayerRepository playerRepository)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
        }
        public async Task<GameVM> Create(GameCreateVM src)
        {
            var newEntity = new Game(src);
            newEntity.CreatedDate = DateTime.UtcNow;

            //Initialize the board with default Guid
            newEntity.Gameboard = new List<int>{
                                0,0,0,
                                0,0,0,
                                0,0,0};

            //Check players are in the system
            await _playerRepository.Verify(src.PlayerIds);
           
            var result = await _gameRepository.Create(newEntity);

            var model = new GameVM(result);
            return model;

        }

    }
}
