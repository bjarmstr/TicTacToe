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
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        public async Task<PlayerVM> Create(PlayerCreateVM src)
        {
            var newEntity = new Player(src);
            newEntity.CreatedDate = DateTime.UtcNow;
            var result = await _playerRepository.Create(newEntity);

            var model = new PlayerVM(result);
            return model;

        }
    }
}
