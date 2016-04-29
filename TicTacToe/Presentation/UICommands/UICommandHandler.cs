using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.UIConsole.Common
{
    public class UICommandHandler : IUICommandChannelHandler
    {
        
        public void Handle(object uiCommandChannel)
        {
            // On ne doit jamais entrer ici
            throw new InvalidOperationException("Operation should not be executed. UICommandChannelChannel implementation error");
        }
    }
}
