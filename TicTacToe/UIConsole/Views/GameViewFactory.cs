using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Presentation.Views;
using TicTacToe.Presentation.UICommands;

namespace TicTacToe.UIConsole.Views
{
    public class GameViewFactory : IGameViewFactory
    {
        public IGameView Create(IUICommandChannel uiCommandChannel)
        {
            return new GameView(uiCommandChannel);
        }
    }
}
