using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.ViewModels
{
    public class GameCreateVM
    {
        [Required]
        public List<Guid> PlayerIds { get; set; }

        public Guid StartPlayer { get; set; }

    }
}
