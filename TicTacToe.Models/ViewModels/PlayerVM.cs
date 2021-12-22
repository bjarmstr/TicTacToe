using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.ViewModels
{
    public class PlayerVM
    {

        public PlayerVM() { }

        public PlayerVM(Entities.Player src)
        {
            Id = src.Id;
            Name = src.Name;

        }
        public Guid Id { get; set; }
        public string Name { get; set; }


    }
}
