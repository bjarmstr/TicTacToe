using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// unique generated Guid identifier for each game
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        public List<int> Gameboard { get; set; }
        
        public Player Player1 { get; set; }

        [Required]
        public Guid Player1Id { get; set; }

        public Player Player2 { get; set; }

        [Required]
        public Guid Player2Id { get; set;
        }

        /// <summary>
        /// winner's id
        /// </summary>
        public Guid? Winner { get;set;}

       }
}
