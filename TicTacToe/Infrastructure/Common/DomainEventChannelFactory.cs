using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.IDomain.Events;

namespace TicTacToe.Infrastructure.Common
{
    public class DomainEventChannelFactory : IDomainEventChannelFactory
    {
        public IDomainEventChannel Create(params IDomainEventHandler[] domainEventHandlers)
        {
            return new DomainEventChannel(domainEventHandlers);
        }
    }
}
