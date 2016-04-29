using TicTacToe.Domain.GameAggregate;
using TicTacToe.UIConsole.Views;
using TicTacToe.IDomain;
using TicTacToe.IDomain.Events;
using TicTacToe.Infrastructure.Common;
using TicTacToe.Presentation.UICommands;
using TicTacToe.Presentation.Views;
using TicTacToe.Application;

namespace TicTacToe
{
    public class CompositionRoot 
    {
        IDomainEventChannel domainEventChannel;
        IGame game ;
        IUICommandChannel uiCommandChannel;
        IGameView gameView;
        FromUICommandsToDomainHandler fromUICommandsToDomainHandler;
        FromDomainEventsToViewHandler fromDomainEventsToViewHandler;

        public CompositionRoot(IDomainEventChannelFactory domainEventChannelFactory,
                               IGameBuilder gameBuilder,
                               IUICommandChannelFactory commandChannelFactory,
                               IGameViewFactory gameViewFactory) 
        {

            // Domain
            this.domainEventChannel = domainEventChannelFactory.Create();
            this.game = gameBuilder.Create(this.domainEventChannel);

            // View
            this.uiCommandChannel = commandChannelFactory.Create();
            this.gameView = gameViewFactory.Create(this.uiCommandChannel);

            // Handlers
            this.fromUICommandsToDomainHandler =
                new FromUICommandsToDomainHandler(this.uiCommandChannel, this.game);

            this.fromDomainEventsToViewHandler =
                new FromDomainEventsToViewHandler(this.domainEventChannel, this.gameView);

        }

       
        public void Execute()
        {
            this.game.Start();
        }

    }
}
