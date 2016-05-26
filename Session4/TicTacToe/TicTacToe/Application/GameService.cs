using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core;
using TicTacToe.Core.Monad;
using TicTacToe.Domain.GameAggregate;
using TicTacToe.IDomain;
using TicTacToe.IDomain.Events;
using TicTacToe.Presentation.UICommands;
using TicTacToe.Presentation.Views;

namespace TicTacToe.Application
{
    public class GameService
    {
        IGameRepository gameRepository;
        Maybe<IDomainEventChannel> domainEventChannel;
        IGameBuilder gameBuilder;

        
        public GameService(Maybe<IDomainEventChannel> domainEventChannel,
                           IGameRepository gameRepository,
                           IGameBuilder gameBuilder)
        {
            this.domainEventChannel = domainEventChannel;
            this.gameRepository = gameRepository;
            this.gameBuilder = gameBuilder;
        }

        public void GenerateNewGame(Guid gameId)
        {
            var domainEventChannel = Maybe<IDomainEventChannel>.Nothing;
            Game game = (Game)gameBuilder.Create(domainEventChannel);
            gameRepository.Add(gameId, game);
        }

        public void StartGame(Guid gameId)
        {
            var game = gameRepository.GetById(gameId);
            game.DomainEventChannel = domainEventChannel;
            game.Start();
        }

        public void ApplyPlayerSelection(Guid gameId, string playerCode, int x, int y)
        {
            var game = gameRepository.GetById(gameId);
            game.DomainEventChannel = domainEventChannel;
            game.ApplyPlayerSelection(playerCode, x, y);
        }
    }
}
