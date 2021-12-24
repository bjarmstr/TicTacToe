using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Shared.Exceptions
{
    public  class IllegalMove: Exception
    {
        public IllegalMove() { }

        public IllegalMove(string message) : base(message)
        {

        }

    }
}
