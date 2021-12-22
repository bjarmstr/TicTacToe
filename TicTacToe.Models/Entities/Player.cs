using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.ViewModels;

namespace TicTacToe.Models.Entities
{
    public class Player
    {
        public Player() { }

        public Player(PlayerCreateVM src)
        {
            Name = src.Name;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public ICollection<Game> Games { get; set; }

    }
}
