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

        /// <summary>
        /// Return the pos of a neighbour cell not visited yet
        /// </summary>
        /// <param name="row">row of the actual cell</param>
        /// <param name="col">column of the actual column</param>
        /// <returns></returns>
        private Tuple<int,int> SelectNeighbour(int row,int col)
        {
            Random rdm = new Random();
            List<Tuple<int,int>> myList = new List<Tuple<int, int>>();

            if (row > 0 && !this.maze[row-1,col].Visited) //North neighbour
            {
                myList.Add(Tuple.Create(row - 1, col)); 
            }
            if(row < this.maze.GetLength(0) - 1 && !this.maze[row + 1, col].Visited) //South neighbour
            {
                myList.Add(Tuple.Create(row + 1, col));
            }
            if(col > 0 && !this.maze[row, col-1].Visited) //West neighbour
            {
                myList.Add(Tuple.Create(row, col-1));
            }
            if(col < this.maze.GetLength(1) - 1 && !this.maze[row, col+1].Visited) //East neigbour
            {
                myList.Add(Tuple.Create(row, col+1));
            }
            if (myList.Count == 0)
            {
                return Tuple.Create(-1, -1);
            }
            else
            {
                int rdmInt = rdm.Next(4);
                return myList[rdmInt];
            }
        }

        /// <summary>
        /// Destroy the wall between 2 cell
        /// </summary>
        /// <param name="row">actual row</param>
        /// <param name="col">actuel col</param>
        /// <param name="nextRow">next row</param>
        /// <param name="nextCol">next col</param>
        private void DestroyWall(int row,int col,int nextRow,int nextCol)
        {
            int diffX = row - nextCol;
            if(diffX == 1) //Remove current north and next south
            {
                this.maze[row, col].N_wall = false;
                this.maze[nextRow, nextCol].S_wall = false;
            }
            if(diffX == -1) //Remove current south and next north
            {
                this.maze[row, col].S_wall = false;
                this.maze[nextRow, nextCol].N_wall = false;
            }
            int diffY = col - nextCol;
            if(diffY == 1) //Remove current's left and next right
            {
                this.maze[row, col].W_wall = false;
                this.maze[nextRow, nextCol].E_wall = false;
            }
            if (diffY == -1) //Remove current's right and next left
            {
                this.maze[row, col].E_wall = false;
                this.maze[nextRow, nextCol].W_wall = false;
            }
        }

        private void Dig(int row,int col, Stack<Tuple<int, int>> stack)
        { 

            this.maze[row, col].Visited = true;
            var neighbour = SelectNeighbour(row, col);
            int nextRow = neighbour.Item1;
            int nextCol = neighbour.Item2;

            if(nextRow != -1)
            {
                stack.Push(Tuple.Create(row, col));
                DestroyWall(row, col, nextRow, nextCol);
                Dig(nextRow, nextCol, stack);

            }
            else if(stack.Count > 0)
            {
                var a = stack.Pop();
                Dig(a.Item1, a.Item2, stack);
            }

            else
            {
                Console.WriteLine("Generation terminée");
            }
        }

        public void printMaze()
        {
            for(int row = 0;row < maze.GetLength(0);row++)
            {
                for(int col = 0;col < maze.GetLength(1);col++)
                {

                }
            }
        }
    }
}
