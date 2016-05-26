namespace TicTacToe.Application
{
    using Core.Monad;
    using TicTacToe.IDomain.Events;
    using TicTacToe.Infrastructure.Common;
    using TicTacToe.Presentation.Views;

    public class FromDomainEventsToViewHandler : Handler,
                    IDomainEventHandler<GameStarted>,
                    IDomainEventHandler<CurrentPlayerChanged>, 
                    IDomainEventHandler<EndOfGameNotification>
    {
        
        IGameView gameView;

        public FromDomainEventsToViewHandler(Maybe<IDomainEventChannel> domainEventChannel,
                                            IGameView gameView)
        {
            this.gameView = gameView;
            domainEventChannel.Do(x => x.AddSubscriber(this));
        }

        public void Handle(GameStarted DomainEvent)
        {
            this.gameView.Render(DomainEvent.GameDtoRefreshed);
        }

        public void Handle(CurrentPlayerChanged DomainEvent)
        {
            this.gameView.Render(DomainEvent.GameDtoRefreshed);
        }

        public void Handle(EndOfGameNotification DomainEvent)
        {
            this.gameView.Render(DomainEvent);
            
        }
    }
}
