using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.IDomain.Events
{
    public interface IDomainEventChannel
    {
        //http://blog.ploeh.dk/2011/09/19/MessageDispatchingwithoutServiceLocation/
        void Submit<DomainEventType>( DomainEventType domainEvent);

        void AddSubscriber(IDomainEventHandler domainEventHandler);

    }
}
