using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Presentation.UICommands
{
    public interface IUICommandChannelFactory
    {
        //http://blog.ploeh.dk/2011/09/19/MessageDispatchingwithoutServiceLocation/
        IUICommandChannel Create(params IUICommandHandler[] uiCommandChannelHandlers);
    }
}
