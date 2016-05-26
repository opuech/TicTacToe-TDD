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
        GameService gameService;
        Guid GameId;

        public FromUICommandsToDomainHandler(IUICommandChannel UICommandChannel, GameService gameService, Guid GameId)
        {
            this.GameId = GameId;
            this.gameService = gameService;
            UICommandChannel.AddSubscriber(this);
        }

        public void Handle(PlayCommand uiCommandChannel)
        {
            gameService.ApplyPlayerSelection(
                    this.GameId,
                    uiCommandChannel.playerCode, 
                    uiCommandChannel.x, 
                    uiCommandChannel.y);
        }
    }
}
