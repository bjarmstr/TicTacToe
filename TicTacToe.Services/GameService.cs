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

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public async Task<GameVM> Create(GameCreateVM src)
        {
            var newEntity = new Game(src);
            newEntity.CreatedDate = DateTime.UtcNow;
            newEntity.Gameboard = new List<int>{ 0,0,3,0,0,0,0,0,0};
            var result = await _gameRepository.Create(newEntity);

            var model = new GameVM(result);
            return model;

        }

    }
}
