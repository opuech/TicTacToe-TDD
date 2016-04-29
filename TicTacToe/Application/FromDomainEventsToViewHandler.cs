namespace TicTacToe.Application
{
    using TicTacToe.IDomain.Events;
    using TicTacToe.Infrastructure.Common;
    using TicTacToe.Presentation.Views;

    public class FromDomainEventsToViewHandler : Handler, 
                    IDomainEventHandler<CurrentPlayerChanged>, 
                    IDomainEventHandler<EndOfGameNotification>
    {
        
        IGameView gameView;

        public FromDomainEventsToViewHandler(IDomainEventChannel domainEventChannel,
                                            IGameView gameView)
        {
            this.gameView = gameView;
            domainEventChannel.AddSubscriber(this);
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
