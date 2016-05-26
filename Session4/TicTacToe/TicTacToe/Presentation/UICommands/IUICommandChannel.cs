using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Presentation.UICommands
{
    public interface IUICommandChannel
    {
        //http://blog.ploeh.dk/2011/09/19/MessageDispatchingwithoutServiceLocation/
        void SubmitUICommand<UICommandChannelType>( UICommandChannelType uiCommand);
        void AddSubscriber(IUICommandHandler uiCommandChannelHandler);
    }
}
