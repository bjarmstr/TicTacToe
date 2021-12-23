using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.ViewModels
{   
    /// <summary>
    /// ViewModel with end of game indicator
    /// </summary>
    public class MoveVM
    {
        /// <summary>
        /// Is the game over?
        /// true if there is a winner or a tie
        /// </summary>
        public bool GameOver { get; set; }

        /// <summary>
        /// true if player wins with this turn
        /// </summary>
        public bool WinningTurn { get; set; }
    }
}
