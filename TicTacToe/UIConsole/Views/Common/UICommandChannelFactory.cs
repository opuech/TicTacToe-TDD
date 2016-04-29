using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Presentation.UICommands;

namespace TicTacToe.Infrastructure.Common
{
    public class UICommandChannelFactory : IUICommandChannelFactory
    {
        //http://blog.ploeh.dk/2011/09/19/MessageDispatchingwithoutServiceLocation/
        public IUICommandChannel Create(params IUICommandHandler[] uiCommandChannelHandlers)
        {
            return new UICommandChannel(uiCommandChannelHandlers);
        }
    }
}
