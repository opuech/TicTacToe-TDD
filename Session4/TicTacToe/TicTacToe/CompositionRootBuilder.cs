

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

        public CompositionRootBuilder WithCommandChannelFactory(IUICommandChannelFactory commandChannelFactory)
        {
            this.commandChannelFactory = commandChannelFactory;
            return this;
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
        public CompositionRootBuilder WithPlayer2(string playerCode)
        {
            gameBuilder.WithPlayer2(playerCode);
            return this;
        }
        public CompositionRootBuilder WithGrid(bool?[,] grid)
        {
            gameBuilder.WithGrid(grid);
            return this;
        }
        public CompositionRootBuilder WithPlayer1AsCurrentPlayer()
        {
            gameBuilder.WithPlayer1AsCurrentPlayer();
            return this;
        }
        public CompositionRootBuilder WithPlayer2AsCurrentPlayer()
        {
            gameBuilder.WithPlayer2AsCurrentPlayer();
            return this;
        }

        public CompositionRoot Create()
        {
            return new CompositionRoot(
                domainEventChannelFactory, gameBuilder, commandChannelFactory, gameViewFactory);
        }

       

    }
}
