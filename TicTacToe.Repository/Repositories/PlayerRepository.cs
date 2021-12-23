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

        /// <summary>
        /// Verify that both players are registerd in the system
        /// Throws exception if not registered
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public async Task Verify(List<Guid> src)
        {
            var playerCount = await _context.Players
                .Where(i => i.Id == src[0] || i.Id == src[1])
                .CountAsync();
           
            if (playerCount !=2) throw new NotFoundException("A requested player could not be found");
        }

    }
}
