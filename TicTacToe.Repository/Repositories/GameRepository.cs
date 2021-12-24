using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities;
using TicTacToe.Repositories.Repositories.Interfaces;
using TicTacToe.Shared.Exceptions;

namespace TicTacToe.Repositories.Repositories
{
    public class GameRepository: IGameRepository
    {
        private readonly ApplicationDbContext _context;

        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Game> Create(Game src)
        {
            _context.Add(src);
            await _context.SaveChangesAsync();
            return src;
        }

        public async Task<Game>Get(Guid id)
        {
            var result = await _context.Games
                .Include(e => e.GamePlayers)
                .FirstOrDefaultAsync(i => i.Id == id);
            if (result == null) throw new NotFoundException("The requested game could not be found");
            return result;
        }

        public async Task<List<Game>>GetAllInProgress(int pageIndex, int pageSize)
        {
            var result = await _context.Games
              .Where(game => game.Gameboard.Contains(9))
              .Include(game => game.GamePlayers).ThenInclude(gp => gp.Player)
              .OrderBy(game => game.CreatedDate)
              .Skip((pageIndex - 1) * pageSize)
              .Take(pageSize)
              .ToListAsync();

            return result;

        }

        public async Task<Game>Update(Game src)
        {
            var result = await _context.Games
                .FirstOrDefaultAsync(i => i.Id == src.Id);
            if (result == null) throw new NotFoundException("The requested game could not be found");

            result.Gameboard = src.Gameboard;
            result.Winner = src.Winner;
            
            await _context.SaveChangesAsync();
            
            return result;
        }

    }
}
