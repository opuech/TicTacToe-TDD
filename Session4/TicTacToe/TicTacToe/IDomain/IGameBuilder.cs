using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core.Monad;

namespace TicTacToe.IDomain
{
    public interface IGameBuilder
    {
        IGameBuilder WithGrid(bool?[,] grid);
        IGameBuilder WithPlayer1(string playerCode);
        IGameBuilder WithPlayer2(string playerCode);
        IGameBuilder WithPlayer1AsCurrentPlayer();
        IGameBuilder WithPlayer2AsCurrentPlayer();
        IGame Create(Maybe<Events.IDomainEventChannel> domainEventChannel);
    }
}
