using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Domain.Common;

namespace TicTacToe.Domain.GameAggregate
{
    public class Grid : ValueObject<Grid>
    {
        private const int X_SIZE = 3;
        private const int Y_SIZE = 3;

        private bool?[,] grid;

        public Grid(bool?[,] grid)
        {
            if(grid == null)
            {
                throw new ArgumentNullException("grid");
            }
            if (grid.GetLength(0) != X_SIZE)
            {
                throw new InvalidOperationException(
                    String.Format("invalid x grid size. actual : {0}. expected : {1}", grid.GetLength(0), X_SIZE));
            }
            if (grid.GetLength(1) != Y_SIZE)
            {
                throw new InvalidOperationException(
                    String.Format("invalid y grid size. actual : {0}. expected : {1}", grid.GetLength(1), Y_SIZE));
            }
            this.grid = grid;
        }

        public Grid Clone()
        {
            var newGrid = new bool?[,] {  { grid[0, 0], grid[1, 0], grid[2, 0] },
                                          { grid[0, 1], grid[1, 1], grid[2, 1] },
                                          { grid[0, 2], grid[1, 2], grid[2, 2] } };
            return new Grid(grid);
        }
        public Grid WithNewPlayerSelection(Player player, int x, int y)
        {
            var newGrid = Clone();
            newGrid.grid[x, y] = player.PlayerMark;
            return newGrid;
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            for (int y = 0; y < Y_SIZE; y += 1)
            {
                for (int x = 0; x < X_SIZE; x += 1)
                {
                    output.Append(
                            grid[x, y].HasValue ? 
                                ((grid[x, y].Value ? 
                                    "X" :                     // X si player 1
                                    "O")) :                   // O si player 2
                                (x + y * X_SIZE).ToString()   // si vide affiche numéro pour identifier la case vide
                                );
                }

            }
            return output.ToString();
        }

        protected override bool EqualsCore(Grid other)
        {
            
            for (int x = 0; x < X_SIZE; x += 1)
            {
                for (int y = 0; y < Y_SIZE; y += 1)
                {
                    if(this.grid[x, y] != other.grid[x, y])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int result = this.grid[0, 0].GetHashCode();
                for (int x = 1; x < X_SIZE; x += 1)
                {
                    for (int y = 0; y < Y_SIZE; y += 1)
                    {
                        result ^= this.grid[x, y].GetHashCode();
                        
                    }
                }
                return result;
            }
        }
    }
}
