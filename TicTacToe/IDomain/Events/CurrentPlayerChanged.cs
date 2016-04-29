using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Domain.GameAggregate;
using TicTacToe.IDomain;
using TicTacToe.IDomain.Dto;
using TicTacToe.Domain.Common;

namespace TicTacToe.IDomain.Events
{
    public class CurrentPlayerChanged : ValueObject<CurrentPlayerChanged>
    {
        public readonly GameDto GameDtoRefreshed;

        public CurrentPlayerChanged(GameDto gameDtoRefreshed)
        {
            this.GameDtoRefreshed = gameDtoRefreshed;
        }

        protected override bool EqualsCore(CurrentPlayerChanged other)
        {
            return (this.GameDtoRefreshed == other.GameDtoRefreshed) ;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                return GameDtoRefreshed.GetHashCode();
            }
        }
    }
}
