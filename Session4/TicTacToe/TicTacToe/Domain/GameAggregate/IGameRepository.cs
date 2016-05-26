using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Domain.GameAggregate
{
    public interface IGameRepository
    {
        void Add(Guid gameId, Game game);

        Game GetById(Guid gameId);
    }
}
