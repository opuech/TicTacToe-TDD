using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Domain.GameAggregate;

namespace TicTacToe.Infrastructure
{
    public class GameInMemoryRepository : IGameRepository
    {
        Dictionary<Guid, Game> GameInmemoryDictionary = new Dictionary<Guid, Game>();

        public void Add(Guid gameId, Game game)
        {
            GameInmemoryDictionary.Add(gameId, game);
        }

        public Game GetById(Guid gameId)
        {
            return GameInmemoryDictionary[gameId];
        }
    }
}
