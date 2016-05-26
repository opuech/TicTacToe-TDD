using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core;
using TicTacToe.Domain.GameAggregate;
using TicTacToe.IDomain;
using TicTacToe.IDomain.Dto;

namespace TicTacToe.IDomain.Events
{
    public class EndOfGameNotification : Immutable<EndOfGameNotification>
    {
        public readonly string winnerPlayerCode;
        public readonly EndOfGameStatus endOfGameStatus;

        public EndOfGameNotification(EndOfGameStatus endOfGameStatus, string winnerPlayerCode)
        {
            this.endOfGameStatus = endOfGameStatus;
            this.winnerPlayerCode = winnerPlayerCode;
        }
    }
}
