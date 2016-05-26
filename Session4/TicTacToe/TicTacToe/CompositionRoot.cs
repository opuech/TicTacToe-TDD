using TicTacToe.Domain.GameAggregate;
using TicTacToe.UIConsole.Views;
using TicTacToe.IDomain;
using TicTacToe.IDomain.Events;
using TicTacToe.Infrastructure.Common;
using TicTacToe.Presentation.UICommands;
using TicTacToe.Presentation.Views;
using TicTacToe.Application;
using TicTacToe.Core.Monad;
using TicTacToe.Infrastructure;
using System;

namespace TicTacToe
{
    public class CompositionRoot 
    {

        Maybe<IDomainEventChannel> domainEventChannel;
        IGame game ;
        IUICommandChannel uiCommandChannel;
        IGameView gameView;
        FromUICommandsToDomainHandler fromUICommandsToDomainHandler;
        FromDomainEventsToViewHandler fromDomainEventsToViewHandler;
        GameService gameService;
        Guid GameId;

        public CompositionRoot(IDomainEventChannelFactory domainEventChannelFactory,
                               IGameBuilder gameBuilder,
                               IUICommandChannelFactory commandChannelFactory,
                               IGameViewFactory gameViewFactory) 
        {
            this.GameId = Guid.NewGuid();

            
            this.domainEventChannel = MaybeConvertions.ToMaybe(domainEventChannelFactory.Create());

            // Application
            gameService = new GameService(this.domainEventChannel,
                           new GameInMemoryRepository(),
                           gameBuilder);

            gameService.GenerateNewGame(this.GameId);
            

            // View
            this.uiCommandChannel = commandChannelFactory.Create();
            this.gameView = gameViewFactory.Create(this.uiCommandChannel);

            // Handlers
            this.fromUICommandsToDomainHandler =
                new FromUICommandsToDomainHandler(this.uiCommandChannel, this.gameService, this.GameId);

            this.fromDomainEventsToViewHandler =
                new FromDomainEventsToViewHandler(this.domainEventChannel, this.gameView);

        }

       
        public void Start()
        {
            this.gameService.StartGame(this.GameId);
        }

        public void ApplyPlayerSelection(string playerCode, int x, int y)
        {
            this.gameService.ApplyPlayerSelection(this.GameId, playerCode, x, y);
        }

    }
}
