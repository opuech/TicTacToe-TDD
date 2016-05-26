using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Domain.GameAggregate;
using TicTacToe.IDomain;
using TicTacToe.IDomain.Dto;
using TicTacToe.IDomain.Events;
using TicTacToe.Presentation.UICommands;

namespace TicTacToe.Presentation.Views
{
    public interface IGameView 
    {
        void Render(GameDto gameDto);

        void Render(EndOfGameNotification DomainEvent);
    }
}
