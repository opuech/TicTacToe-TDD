using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.IDomain;
using TicTacToe.IDomain.Dto;

namespace TicTacToe.IDomain
{
    public interface IGame
    {
        string GetCurrentGrid();
        string GetPlayer1Code();
        string GetPlayer2Code();
        void Start();

        void ApplyPlayerSelection(string playerCode, int x, int y);
    }
}
