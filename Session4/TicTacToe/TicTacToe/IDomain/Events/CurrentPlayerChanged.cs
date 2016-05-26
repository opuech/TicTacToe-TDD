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
    public class CurrentPlayerChanged : Immutable<CurrentPlayerChanged>
    {
        public readonly GameDto GameDtoRefreshed;

        public CurrentPlayerChanged(GameDto gameDtoRefreshed)
        {
            this.GameDtoRefreshed = gameDtoRefreshed;
        }
    }
}
