using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities;

namespace TicTacToe.Models.ViewModels
{
    /// <summary>
    /// stats for game in progress
    /// moves completed by each player 
    /// </summary>
    public class GameInProgressVM
    {

        /// <summary>
        /// Games in Progess
        /// default constructor
        /// </summary>
        public GameInProgressVM() { }

        /// <summary>
        /// Create GameInprogressVM from Game Entity
        /// </summary>
        public GameInProgressVM(Guid gameId)
        {
            Id = gameId;
            
          
        }

        /// <summary>
        /// Id of the Game
        /// </summary>
        public Guid Id { get; set; }

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
        public int Player2Moves { get; set; }


    }
}
