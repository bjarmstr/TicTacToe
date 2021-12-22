using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities;
using TicTacToe.Repositories.Repositories.Interfaces;

namespace TicTacToe.Repositories.Repositories
{
    public class PlayerRepository: IPlayerRepository
    {
        private readonly ApplicationDbContext _context;

        public PlayerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Player>Create(Player src)
        {
            _context.Players.Add(src);
            await _context.SaveChangesAsync();
            return src;
        }

    }
}
