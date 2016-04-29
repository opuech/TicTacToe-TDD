using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Domain.Common;

namespace TicTacToe.Presentation.UICommands
{
    public class PlayCommand : ValueObject<PlayCommand>
    {
        public readonly string playerCode;
        public readonly int x;
        public readonly int y;

        public PlayCommand(string playerCode, int x, int y)
        {
            this.playerCode = playerCode;
            this.x = x;
            this.y = y;
        }

        protected override bool EqualsCore(PlayCommand other)
        {
            return (playerCode == other.playerCode) && (x == other.x) && (y == other.y);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                return playerCode.GetHashCode() * 1024 + x.GetHashCode() * 32 + x.GetHashCode() * 4;
            }
        }
    }
}
