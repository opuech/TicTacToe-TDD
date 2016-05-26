using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Domain.Common;

namespace TicTacToe.IDomain.Dto
{
    public class GameDto :  ValueObject<GameDto>
    {
        public string Grid { get; private set; }
        public string CurrentPlayerCode { get; private set; }

        public GameDto(string grid, string currentPlayerCode)
        {
            this.Grid = grid;
            this.CurrentPlayerCode = currentPlayerCode;
        }

        protected override bool EqualsCore(GameDto other)
        {
            return (this.Grid == other.Grid) && (this.CurrentPlayerCode == other.CurrentPlayerCode);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                return this.Grid.GetHashCode() ^ this.CurrentPlayerCode.GetHashCode();
            }
        }
    }
}
