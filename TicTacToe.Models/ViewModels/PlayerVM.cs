using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.ViewModels
{
    /// <summary>
    /// Player ViewModel
    /// </summary>
    public class PlayerVM
    {
        /// <summary>
        /// Generic constructor for Player View Model
        /// </summary>
        public PlayerVM() { }

        /// <summary>
        /// Constructor for Player Entity to VM
        /// </summary>
        /// <param name="src"></param>
        public PlayerVM(Entities.Player src)
        {
            Id = src.Id;
            Name = src.Name;

        }
        /// <summary>
        /// Unique Identifier for Player
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Name of Player 
        /// </summary>
        public string Name { get; set; }


    }
}
