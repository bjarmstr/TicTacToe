using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.ViewModels
{
    /// <summary>
    /// VM for Creation of a Game
    /// </summary>
    public class GameCreateVM
    {
        /// <summary>
        /// 2 player ids are required
        /// create player ids with create player endpoint
        /// </summary>
        [Required]
        public List<Guid> PlayerIds { get; set; }

        /// <summary>
        /// start player has the first turn
        /// start player must be one of this game's players
        /// </summary>
        public Guid StartPlayer { get; set; }

    }
}
