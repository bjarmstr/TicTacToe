﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Entities
{
    public class Player
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }



    }
}
