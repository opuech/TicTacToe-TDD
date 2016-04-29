using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.IDomain;
using TicTacToe.IDomain.Events;
using TicTacToe.IDomain.Dto;
using TicTacToe.Domain.Common;

namespace TicTacToe.Domain.GameAggregate
{
    public class GameBuilder : IGameBuilder
    {
        private Guid GameId;
        private bool?[,] grid;
        private EndOfGameStatus? endOfGameStatus;
        private Player player1;
        private Player player2;
        private int? currentPlayer;

        public GameBuilder()
        {
            GameId = Guid.NewGuid();

            player1 = new Player("Player 1", true);
            player2 = new Player("Player 2", false);

            grid = new bool?[,] { { null, null, null }, 
                                  { null, null, null }, 
                                  { null, null, null } };
            currentPlayer = null;
            endOfGameStatus = null;
        }

        public IGameBuilder WithGrid(bool?[,] grid)
        {

            this.grid = grid;

            return this;
        }

        public IGameBuilder WithPlayer1(string playerCode)
        {
            player1 = new Player(playerCode, true);
           
            return this;
        }

        public IGameBuilder WithPlayer2(string playerCode)
        {
            player2 = new Player(playerCode, false);

            return this;
        }

        public IGameBuilder WithCurrentPlayer(int? currentPlayer)
        {
            this.currentPlayer = currentPlayer;

            return this;
        }

        public IGame Create(IDomainEventChannel domainEventChannel)
        {
            if (domainEventChannel == null)
            {
                throw new ArgumentNullException("domainEventChannel");
            }

            return new Game(domainEventChannel, 
                            GameId, 
                            new Player[] {player1, player2}, 
                            currentPlayer,
                            new Grid(grid));
        }
    }
}
