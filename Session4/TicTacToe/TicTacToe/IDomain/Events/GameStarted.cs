using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Domain.GameAggregate;
using TicTacToe.IDomain;
using TicTacToe.IDomain.Dto;
using TicTacToe.Domain.Common;
using TicTacToe.Core;

namespace TicTacToe.IDomain.Events
{
    public class GameStarted : Immutable<GameStarted>
    {
        public readonly GameDto GameDtoRefreshed;

        public GameStarted(GameDto gameDtoRefreshed)
        {
            this.GameDtoRefreshed = gameDtoRefreshed;
        }
    }
}
