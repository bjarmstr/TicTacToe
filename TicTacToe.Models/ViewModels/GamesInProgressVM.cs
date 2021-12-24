using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.ViewModels
{
    /// <summary>
    /// stats for game in progress
    /// moves completed by each player 
    /// </summary>
    public class GameInProgressVM
    {
        /// <summary>
        /// Name of the starting player
        /// </summary>
        public string Player1 { get; set; }
       
        /// <summary>
        /// Moves completed by Player1
        /// </summary>
        public int Player1Moves { get; set;}
        
        /// <summary>
        /// Name of second player
        /// </summary>
        public string Player2 { get; set; }

        /// <summary>
        /// Moves completed by Player2
        /// </summary>
        public string Player2Moves { get; set; }


    }
}
