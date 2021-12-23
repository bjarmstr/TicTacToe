using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.ViewModels;

namespace TicTacToe.Services.Interfaces
{
    public interface IGameService
    {
        Task<GameVM> Create(GameCreateVM data);
        Task<MoveVM> Move(MoveCreateVM data);

    }
}
