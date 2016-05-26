using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Presentation.UICommands;

namespace TicTacToe.Infrastructure.Common
{
    //http://blog.ploeh.dk/2011/09/19/MessageDispatchingwithoutServiceLocation/
    public class UICommandChannel : IUICommandChannel
    {
        private readonly List<IUICommandHandler> uiCommandChannelHandlers;

        public UICommandChannel(params IUICommandHandler[] uiCommandChannelHandlers)
        {

            if (uiCommandChannelHandlers == null)
            {
                throw new ArgumentNullException("uiCommandChannelHandlers");
            }
            this.uiCommandChannelHandlers = uiCommandChannelHandlers.ToList();
        }

        public void AddSubscriber(IUICommandHandler uiCommandChannelHandler)
        {
            uiCommandChannelHandlers.Add(uiCommandChannelHandler);
        }

        public void SubmitUICommand<UICommandChannelType>(UICommandChannelType uiCommandChannel)
        {
            foreach (var uiCommandChannelHandler in this.uiCommandChannelHandlers)
            {
                if (uiCommandChannelHandler is IUICommandHandler<UICommandChannelType>)
                {
                    (uiCommandChannelHandler as IUICommandHandler<UICommandChannelType>).Handle((UICommandChannelType)uiCommandChannel);
                }
            }
        }
    }
}
