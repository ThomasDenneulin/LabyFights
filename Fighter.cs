using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabyFights
{
    class Fighter
    {
        int lifePoint;
        int damage;
        bool aggressif;
        Maze maze;
        int currentRow;
        int currentCol;
        Stack<Tuple<int, int>> visitedCell;
        public Fighter(bool aggressif, Maze maze, int row, int col)
        {
            this.lifePoint = 100;
            this.damage = 10;
            this.aggressif = aggressif;
            this.maze = maze;
            this.currentCol = col;
            this.currentRow = row;
            Thread threadWhosMovingFighter = new Thread(Move);
        }

        private void Move()
        {
            visitedCell = new Stack<Tuple<int, int>>();
            while(currentRow != this.maze.Exit.Item1 && currentCol != this.maze.Exit.Item2)
            {
                
            }
        }
    }
}
