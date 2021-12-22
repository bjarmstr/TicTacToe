using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities;

namespace TicTacToe.Repositories.Repositories.Interfaces
{
    public  interface IPlayerRepository
    {
        Task<Player> Create(Player src);
    }
}
