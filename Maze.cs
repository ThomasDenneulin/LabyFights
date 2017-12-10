using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyFights
{
    /*Le labyrinthe est une entité unique, jouant le rôle d’élément central. Il est de forme
    rectangulaire entièrement entouré de murs. Les murs et la sortie sont des cases particulières*/
    class Maze
    {
        private Cell[,] maze;
        private int width;
        private int height;

        public Maze(int width,int height)
        {
            this.width = width;
            this.height = height;
            this.maze = new Cell[height, width];
            for(int row = 0; row < height; row++)
            {
                for(int col = 0; col < width; width++)
                {
                    this.maze[row, col] = new Cell();
                }
            }
        }

        //Do it with tuple class
        private Cell SelectNeighbour(int row,int col)
        {
            List<Cell> cellList = new List<Cell>();

            if (row > 0 && !this.maze[row-1,col].Visited) //North neighbour
            {
                cellList.Add(this.maze[row - 1, col]);
            }
            if(row < this.maze.GetLength(0) - 1) //South neighbour
            {
                cellList.Add(this.maze[row + 1, col]);
            }
            if(col > 0) //West neighbour
            {
                cellList.Add(this.maze[row, col - 1]);
            }
            if(col < this.maze.GetLength(1) - 1) //East neigbour
            {
                cellList.Add(this.maze[row, col + 1]);
            }

            return new Cell();
        }
    }
}
