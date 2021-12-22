using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.ViewModels;

namespace TicTacToe.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<PlayerVM> Create(PlayerCreateVM data);
    }
}
