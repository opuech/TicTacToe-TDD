using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.IDomain.Events;
using TicTacToe.Presentation.UICommands;

namespace TicTacToe.Infrastructure.Common
{
    public class Handler : IDomainEventHandler, IUICommandHandler
    {
        
        public void Handle(object obj)
        {
            // On ne doit jamais entrer ici
            throw new InvalidOperationException("Operation should not be executed. DomainEventChannel implementation error");
        }
    }
}
