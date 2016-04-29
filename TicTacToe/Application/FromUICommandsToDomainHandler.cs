using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TicTacToe.IDomain;
using TicTacToe.IDomain.Events;
using TicTacToe.IDomain.Dto;
using TicTacToe.Infrastructure.Common;
using TicTacToe.UIConsole.Views;
using TicTacToe.Presentation.UICommands;

namespace TicTacToe.Application
{
    public class FromUICommandsToDomainHandler : Handler, 
                    IUICommandHandler<PlayCommand>
    {
        IGame game;

        public FromUICommandsToDomainHandler(IUICommandChannel UICommandChannel, IGame game)
        {
            this.game = game;
            UICommandChannel.AddSubscriber(this);
        }

        public void Handle(PlayCommand uiCommandChannel)
        {
            game.ApplyPlayerSelection(
                    uiCommandChannel.playerCode, 
                    uiCommandChannel.x, 
                    uiCommandChannel.y);
        }
    }
}
