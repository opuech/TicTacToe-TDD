

namespace TicTacToe
{
    using TicTacToe.Application;
    using TicTacToe.Domain.GameAggregate;
    using TicTacToe.IDomain;
    using TicTacToe.IDomain.Events;
    using TicTacToe.Infrastructure.Common;
    using TicTacToe.Presentation.UICommands;
    using TicTacToe.Presentation.Views;
    using TicTacToe.UIConsole.Views;
    

    public class CompositionRootBuilder 
    {
        public IDomainEventChannelFactory domainEventChannelFactory;
        public IGameBuilder gameBuilder;
        public IUICommandChannelFactory commandChannelFactory;
        public IGameViewFactory gameViewFactory;

        public CompositionRootBuilder()
        {
            domainEventChannelFactory = new DomainEventChannelFactory();
            gameBuilder = new GameBuilder();
            commandChannelFactory = new UICommandChannelFactory();
            gameViewFactory = new GameViewFactory();
        }

        public CompositionRootBuilder WithGameViewFactory(IGameViewFactory gameViewFactory)
        {
            this.gameViewFactory = gameViewFactory;
            return this;
        }
        public CompositionRootBuilder WithPlayer1(string playerCode)
        {
            gameBuilder.WithPlayer1(playerCode);
            return this;
        }

        public CompositionRoot Create()
        {
            return new CompositionRoot(
                domainEventChannelFactory, gameBuilder, commandChannelFactory, gameViewFactory);
        }

       

    }
}
