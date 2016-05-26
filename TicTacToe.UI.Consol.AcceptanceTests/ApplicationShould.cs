using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

using TicTacToe;
using TicTacToe.Presentation.Views;
using TicTacToe.Presentation.UICommands;
using TicTacToe.IDomain.Dto;

namespace TicTacToe.AcceptanceTests
{
    [TestClass]
    public class ApplicationShould
    {
        /*
         * 
         * Quand la page d'accueil est appelée, alors le message "Hello" s'affiche
         *  
         * 
         * Etant donné un début de partie
         *  Quand le jeu s'initialise
         *      Alors la grille devrait s'afficher vide
         *          et ça devrait être au tour du joueur 1
         *          
         * Etant donné une grille de jeu quelconque  
         *  Quand le joueur à qui c'est le tour sélectionne une case
         *      Alors la position sélectionnée devrait porter la marque du joueur qui l'a sélectionné 
         *          (X pour joueur 1 et 'O' pour joueur 2)
         *          et ça devrait être au tour de l'autre joueur
         *         
         * Etant donné une grille de jeu quelconque
         *  Quand le joueur à qui c'est le tour sélectionne un case occupée
         *   Alors le jeu devrait bloquer le coup et avertir le joueur 
         *   
         * Etant donné une grille de jeu quelconque
         *  Quand le joueur à qui c'est le tour sélectionne un case hors du champ de la grille
         *   Alors le jeu devrait bloquer le coup et avertir le joueur 
         *   
         * Etant donné une grille de jeu 
         *      dont il reste un coup à un joueur pour gagner la partie
         *           et que c'est à son tour de jouer
         *  Quand il sélectionne la 3ème case consécutive alignée sur la même ligne, colonne ou diagonale
         *   Alors le jeu devrait l'annoncer comme vainqueur
         *   
         * Etant donné une grille de jeu 
         *      dont il reste un coup à jouer car la grille est pleine 
         *          et que ce coup n'est pas gagnant
         *  Quand le joueur à qui c'est le tour sélectionne la drnière case
         *   Alors le jeu devrait annoncer la partie nulle
         * 
        */
        

        [TestMethod]
        public void Given_NewGame_With_Player1_When_Game_Starts_Then_EmptyGrid_Is_Rendered_For_Player1()
        {
            using (var consoleHooker = new TestsHelpers.ConsoleHooker())
            {   
                // Arrange
                string expectedPlayer = "Player1";
                string expectedGrid = "012345678";
                var stubGameViewFactory = Substitute.For<IGameViewFactory>();
                var sutBuilder = new CompositionRootBuilder().WithPlayer1(expectedPlayer).WithGameViewFactory(stubGameViewFactory);
                var moq = Substitute.For<IGameView>();
                stubGameViewFactory.Create(Arg.Any<IUICommandChannel>()).Returns(moq);
                var sut = sutBuilder.Create();

                // Act
                sut.Start();

                // Assert
                moq.Received().Render(new GameDto(expectedGrid, expectedPlayer));
                
            }
        }

        /* Etant donné une grille de jeu quelconque
  * Quand le joueur à qui c'est le tour sélectionne une case
  *      Alors la position sélectionnée devrait porter la marque du joueur qui l'a sélectionné 
  *          (X pour joueur 1 et 'O' pour joueur 2)
  *          et ça devrait être au tour de l'autre joueur*/
        [TestMethod]
        public void Given_SomeGame_With_Player2_When_Player2_Select_A_Case_Then_The_Case_Is_Marked_By_O_And_Player1_Could_Play()
        {
            using (var consoleHooker = new TestsHelpers.ConsoleHooker())
            {
                // Arrange
                string expectedPlayer = "Vince";
                string Player2 = "kavin";
                string expectedGrid = "XO2OOXX78";
                var stubGameViewFactory = Substitute.For<IGameViewFactory>();
                var moq = Substitute.For<IGameView>();
                stubGameViewFactory.Create(Arg.Any<IUICommandChannel>()).Returns(moq);

                var sutBuilder = new CompositionRootBuilder()
                    .WithPlayer1(expectedPlayer)
                    .WithPlayer2(Player2)
                    .WithPlayer2AsCurrentPlayer()
                    .WithGrid(new bool?[,]
                        { { true, false, true },
                          { null, false, null },
                          { null, true, null } })
                    .WithGameViewFactory(stubGameViewFactory);
                var sut = sutBuilder.Create();

                // Act
                sut.ApplyPlayerSelection(Player2, 1, 0);

                // Assert
                moq.Received().Render(new GameDto(expectedGrid, expectedPlayer));

            }
        }
    }
}
