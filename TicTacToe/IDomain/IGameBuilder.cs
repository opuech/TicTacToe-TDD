using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.IDomain
{
    public interface IGameBuilder
    {
        IGameBuilder WithGrid(bool?[,] grid);
        IGameBuilder WithPlayer1(string playerCode);
        IGameBuilder WithPlayer2(string playerCode);
        IGameBuilder WithCurrentPlayer(int? currentPlayer);
        IGame Create(Events.IDomainEventChannel domainEventChannel);
    }
}
