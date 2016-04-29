using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TicTacToe.Domain.GameAggregate;
using TicTacToe.UIConsole.Views;
using TicTacToe.IDomain.Dto;
using TicTacToe.IDomain.Events;
using TicTacToe.Infrastructure.Common;
using TicTacToe.Presentation.UICommands;
using NSubstitute;

namespace TicTacToe.UnitTests.Domain.GameAggregate
{
    /// <summary>
    /// Summary description for GameTest
    /// </summary>
    [TestClass]
    public class GameShould
    {
        
        /*
         * * Etant donné un début de partie
         *  Quand le jeu s'initialise
         *      Alors la grille devrait s'afficher vide
         *          et ça devrait être au tour du joueur 1 
         */
        [TestMethod]
        public void Given_NewGame_With_Player1_When_Game_Starts_Then_Initialization_CurrentPlayerChanged_Event_Is_Sent()
        {
            // Arrange
            var moqDomainEventChannel = Substitute.For<IDomainEventChannel>();
            var gameBuilder = new GameBuilder();
            var sut = gameBuilder.WithPlayer1("Player1").WithPlayer2("dummy").Create(moqDomainEventChannel);

            // Act
            sut.Start();

            // Assert
            moqDomainEventChannel.Received().Submit<CurrentPlayerChanged>(
                new CurrentPlayerChanged(
                        new GameDto("012345678", "Player1")));
        }

        [TestMethod]
        public void test1()
        {
            GameDto g1 = new GameDto("012345678", "Player1");
            GameDto g2 = new GameDto("012345678", "Player1");
            Assert.AreEqual<GameDto>(g1, g2);
        }

        [TestMethod]
        public void test2()
        {
            CurrentPlayerChanged g1 = new CurrentPlayerChanged(new GameDto("012345678", "Player1"));
            CurrentPlayerChanged g2 = new CurrentPlayerChanged(new GameDto("012345678", "Player1"));
            Assert.AreEqual<CurrentPlayerChanged>(g1, g2);
        }
    }
}
