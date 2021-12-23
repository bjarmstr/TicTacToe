using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.ViewModels
{
    /// <summary>
    /// Place a move on the board
    /// </summary>
    public class MoveCreateVM
    {
        /// <summary>
        /// Id for the Game being played
        /// </summary>
        [Required]
        public Guid GameId { get; set; }

        /// <summary>
        /// Player whose turn it is in the game
        /// </summary>
        [Required]
        public Guid Player { get; set; }

        /// <summary>
        /// Numbers 0-8 coresponding to the 9 squares on the board
        /// Top left square is 0, Top right square is 2
        /// Middle is 4
        /// Bottom left is 6,  Bottom right is 8
        /// </summary>
        [Required]
        public int Location { get; set; }

    }
}
