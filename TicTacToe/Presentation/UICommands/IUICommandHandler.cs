using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Presentation.UICommands
{
    public interface IUICommandHandler 
    {
    }
    public interface IUICommandHandler<UICommandType> : IUICommandHandler
    {
        void Handle(UICommandType uiCommandChannel);
    }
}
