using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.IDomain.Events;

namespace TicTacToe.Infrastructure.Common
{
    //http://blog.ploeh.dk/2011/09/19/MessageDispatchingwithoutServiceLocation/
    public class DomainEventChannel : IDomainEventChannel
    {
        private readonly List<IDomainEventHandler> domainEventHandlers;

        public DomainEventChannel(params IDomainEventHandler[] domainEventHandlers)
        {

            if (domainEventHandlers == null)
            {
                throw new ArgumentNullException("domainEventHandlers");
            }
            this.domainEventHandlers = domainEventHandlers.ToList();
        }

        public void AddSubscriber(IDomainEventHandler domainEventHandler)
        {
            domainEventHandlers.Add(domainEventHandler);
        }

        public void Submit<DomainEventType>(DomainEventType domainEvent)
        {
            foreach (var DomainEventHandler in this.domainEventHandlers)
            {
                if (DomainEventHandler is IDomainEventHandler<DomainEventType>)
                {
                    (DomainEventHandler as IDomainEventHandler<DomainEventType>).Handle((DomainEventType)domainEvent);
                }
            }
        }
    }
}
