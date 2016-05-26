using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.IDomain.Events;

namespace TicTacToe.IDomain.Events
{
    public interface IDomainEventChannelFactory
    {
        IDomainEventChannel Create(params IDomainEventHandler[] domainEventHandlers);
    }
}
