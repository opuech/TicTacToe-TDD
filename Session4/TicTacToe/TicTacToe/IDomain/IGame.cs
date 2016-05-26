using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core;
using TicTacToe.IDomain;
using TicTacToe.IDomain.Dto;

namespace TicTacToe.IDomain
{
    public interface IGame
    {
        void Start();

        Result ApplyPlayerSelection(string playerCode, int x, int y);
    }
}
