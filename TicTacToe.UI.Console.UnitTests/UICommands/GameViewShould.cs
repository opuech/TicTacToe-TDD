using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Presentation.UICommands;
using TicTacToe.UIConsole.Views;
using TicTacToe.IDomain.Dto;
using TicTacToe.UnitTests;
using NSubstitute;

namespace TicTacToe.UnitTests.UICommands
{
    [TestClass]
    public class GameViewShould
    {
        /*
         * * Etant donné un début de partie
         *  Quand le jeu s'initialise
         *      Alors la grille devrait s'afficher vide
         *          et ça devrait être au tour du joueur 1 
         */
        [TestMethod]
        public void Given_Player1_EmptyGrid_To_Render_When_Rendering_Is_Called_Then_Player1_EmptyGrid_Is_Displayed()
        {

            using (var consoleHooker = new TestsHelpers.ConsoleHooker())
            {
                // Arrange
                var uiCommandChannel = Substitute.For<IUICommandChannel>(); ;
                var sut = new GameView(uiCommandChannel);
                
                // Act
                sut.Render(new GameDto("012345678", "Player1"));

                // Assert
                var actualResult = consoleHooker.@out.ToString();
                Assert.AreEqual<string>("Grid :\r\n\r\n 0 1 2\n 3 4 5\n 6 7 8\n\n\r\nPlayer1, this your turn\r\nSelect and press enter :", actualResult);
            }
          
        }

        [TestMethod]
        public void Given_Player1_With_EmptyGrid_When_He_Selects_Case_3_Then_Player1_X0_Y1_PlayCommand_Is_Send()
        {

            using (var consoleHooker = new TestsHelpers.ConsoleHooker())
            {
                // Arrange
                var uiCommandChannel = Substitute.For<IUICommandChannel>(); ;
                var sut = new GameView(uiCommandChannel);
                
                //Act
                consoleHooker.WriteLineToInBuffer("3");
                sut.Render(new GameDto("012345678", "Player1"));

                //Assert
                uiCommandChannel.Received().SubmitUICommand(new PlayCommand("Player1", 0, 1));
               
            }

        }
    }
}
