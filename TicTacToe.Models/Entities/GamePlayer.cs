using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities
{

    /// <summary>
    /// Join table for Games and Players
    /// </summary>
    public class GamePlayer
    {
        /// <summary>
        /// Game Id
        /// </summary>
        public Guid GameId { get; set; }
        
        /// <summary>
        ///Player Id 
        /// </summary>
        public Guid PlayerId { get; set; }

        /// <summary>
        /// navigation property for player
        /// </summary>
        public Player Player { get; set; }
        
        /// <summary>
        /// navigation property for game 
        /// </summary>
        public Game Game { get; set; }


    }
}
