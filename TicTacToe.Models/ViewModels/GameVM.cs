using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.ViewModels
{
    /// <summary>
    /// VM for Game and Players Id
    /// </summary>
    public class GameVM
    {
        /// <summary>
        /// GameVM - Return GameId and Players Ids
        /// </summary>
        public GameVM() { }

        /// <summary>
        /// Create GameVM from Game Entity
        /// </summary>
        /// <param name="src"></param>
        public GameVM(Entities.Game src)
        {
            Id = src.Id;
            PlayerIds = src.GamePlayers.Select(id => id.PlayerId).ToList();

        }

        /// <summary>
        /// Unique Guid Id for the Game
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// List of 2 player Ids
        /// </summary>
        public List<Guid> PlayerIds { get; set; }
    }
}
