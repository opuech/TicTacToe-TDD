using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Domain.Common;

namespace TicTacToe.Domain.GameAggregate
{
    public class Player : ValueObject<Player>
    {
        public string PlayerCode { get; private set; }
        public bool PlayerMark { get; private set; }

        public Player(string playerCode, bool playerMark)
        {
            this.PlayerCode = playerCode;
            this.PlayerMark = playerMark;
        }

        protected override bool EqualsCore(Player other)
        {
            return (this.PlayerCode == other.PlayerCode) && (this.PlayerMark == other.PlayerMark);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                return this.PlayerCode.GetHashCode() ^ this.PlayerMark.GetHashCode();
            }
        }
    }
}
