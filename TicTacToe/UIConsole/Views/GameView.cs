using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Domain.GameAggregate;
using TicTacToe.IDomain;
using TicTacToe.IDomain.Dto;
using TicTacToe.IDomain.Events;
using TicTacToe.Presentation.UICommands;
using TicTacToe.Presentation.Views;

namespace TicTacToe.UIConsole.Views
{
    public class GameView : IGameView
    {
        IUICommandChannel uiCommandChannel;

        public GameView(IUICommandChannel uiCommandChannel)
        {
            this.uiCommandChannel = uiCommandChannel;
        }

        public void Render(GameDto gameDto)
        {
            System.Console.WriteLine("Grid :");
            System.Console.WriteLine();
            System.Console.WriteLine(String.Format(" {0} {1} {2}\n {3} {4} {5}\n {6} {7} {8}\n\n", 
                                                    gameDto.Grid[0],
                                                    gameDto.Grid[1],
                                                    gameDto.Grid[2],
                                                    gameDto.Grid[3],
                                                    gameDto.Grid[4],
                                                    gameDto.Grid[5],
                                                    gameDto.Grid[6],
                                                    gameDto.Grid[7],
                                                    gameDto.Grid[8]));
            System.Console.WriteLine(String.Format("{0}, this your turn", gameDto.CurrentPlayerCode));
            System.Console.Write("Select and press enter :");
            string text = Console.ReadLine();
            int userSelection;
            if (Int32.TryParse(text, out userSelection))
            {
                uiCommandChannel.SubmitUICommand<PlayCommand>(
                new PlayCommand(gameDto.CurrentPlayerCode, userSelection % 3, userSelection / 3));
            }
        }

        public void Render(EndOfGameNotification DomainEvent)
        {
            switch (DomainEvent.endOfGameStatus)
            {
                case EndOfGameStatus.Equality: { Console.WriteLine("Égalité!"); } break;
                case EndOfGameStatus.APlayerWins: { Console.WriteLine(String.Format("Vainqueur : {0}", DomainEvent.winnerPlayerCode)); } break;
            }
        }


    }
}
