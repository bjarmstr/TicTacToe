using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.ViewModels;

namespace TicTacToe.Models.Entities
{
    /// <summary>
    /// entity for a game
    /// </summary>
    public class Game
    {
        /// <summary>
        /// a game of tic tac toe
        /// </summary>
        public Game() { }

    
        public Game(GameCreateVM src)
        {
            GamePlayers = src.PlayerIds.Select(id => new GamePlayer { PlayerId = id }).ToList();
            StartPlayer = src.StartPlayer;
        }

        /// <summary>
        /// unique generated Guid identifier for each game
        /// </summary>
        [Key]
        public Guid Id { get; set; }

       /// <summary>
       /// a list from 0-8 where game moves are stored
       /// player1 moves are stored as 1
       /// player2 moves are stored as 2
       /// unplayed squares are stored as 9
       /// </summary>
        public List<int> Gameboard { get; set; }

        /// <summary>
        /// navigation property to game players
        /// </summary>
        //navigation property 
        public ICollection<GamePlayer> GamePlayers { get; set; }

        /// <summary>
        /// Id of player selected to go first
        /// </summary>
        public Guid StartPlayer { get; set; }
  
        /// <summary>
        /// winner's id
        /// </summary>
        public Guid? Winner { get;set;}

        /// <summary>
        /// date Game was created on
        /// </summary>
        [Required]
        public DateTime CreatedDate { get; set; }

    }
}
