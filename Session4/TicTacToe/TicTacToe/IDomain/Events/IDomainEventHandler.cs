using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.IDomain.Events
{
    public interface IDomainEventHandler
    {
        void Handle(object domainEvent);
    }
    public interface IDomainEventHandler<DomainEventType> : IDomainEventHandler
    {
        void Handle(DomainEventType DomainEvent);
    }
}
