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
    /// Player Information
    /// </summary>
    public class Player
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public Player() { }

        /// <summary>
        /// Constructor to convert PlayerCreateVM to Player
        /// </summary>
        /// <param name="src"></param>
        public Player(PlayerCreateVM src)
        {
            Name = src.Name;
        }

        /// <summary>
        /// Unique identifier for Player
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Name of player
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Date and Time Player was created
        /// </summary>
        [Required]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Collection of Games associated with this Player
        /// </summary>
        public ICollection<GamePlayer> GamePlayers { get; set; }

    }
}
