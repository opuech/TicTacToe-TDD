using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Presentation.Views;
using TicTacToe.Presentation.UICommands;

namespace TicTacToe.Presentation.Views
{
    public interface IGameViewFactory
    {
        IGameView Create(IUICommandChannel uiCommandChannel);
    }
}
