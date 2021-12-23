using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.ViewModels
{
    public class GameVM
    {
        public GameVM() { }

        public GameVM(Entities.Game src)
        {
            Id = src.Id;
           // PlayerIds = src.GamePlayers.Select(id => Id = id.Player.Id).ToList();

        }
        public Guid Id { get; set; }

        public List<Guid> PlayerIds { get; set; }
    }
}
