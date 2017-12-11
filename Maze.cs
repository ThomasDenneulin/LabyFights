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
        private Cell[,] myMaze;
        private int width;
        private int height;
        Random rdm;

        public Cell[,] MyMaze
        {
            get
            {
                return myMaze;
            }

            set
            {
                myMaze = value;
            }
        }

        public Maze(int width,int height, Random rdm)
        {
            this.width = width;
            this.height = height;
            this.myMaze = new Cell[height, width];
            this.rdm = rdm;
            for(int row = 0; row < height; row++)
            {
                for(int col = 0; col < width; col++)
                {
                    this.myMaze[row, col] = new Cell();
                }
            }
            Dig(0, 0, new Stack<Tuple<int, int>>());
        }

        /// <summary>
        /// Return the pos of a neighbour cell not visited yet
        /// </summary>
        /// <param name="row">row of the actual cell</param>
        /// <param name="col">column of the actual column</param>
        /// <returns></returns>
        private Tuple<int,int> SelectNeighbour(int row,int col)
        {
            Random myRdm = this.rdm;
            List<Tuple<int,int>> myList = new List<Tuple<int, int>>();

            if (row > 0 && !this.myMaze[row-1,col].Visited) //North neighbour
            {
                myList.Add(Tuple.Create(row - 1, col)); 
            }
            if(row < this.myMaze.GetLength(0) - 1 && !this.myMaze[row + 1, col].Visited) //South neighbour
            {
                myList.Add(Tuple.Create(row + 1, col));
            }
            if(col > 0 && !this.myMaze[row, col-1].Visited) //West neighbour
            {
                myList.Add(Tuple.Create(row, col-1));
            }
            if(col < this.myMaze.GetLength(1) - 1 && !this.myMaze[row, col+1].Visited) //East neigbour
            {
                myList.Add(Tuple.Create(row, col+1));
            }
            if (myList.Count == 0)
            {
                return Tuple.Create(-1, -1);
            }
            else
            {
                int rdmInt = rdm.Next(myList.Count);
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
            int diffX = row - nextRow;
            if(diffX == 1) //Remove current north and next south
            {
                this.myMaze[row, col].N_wall = false;
                this.myMaze[nextRow, nextCol].S_wall = false;
            }
            if(diffX == -1) //Remove current south and next north
            {
                this.myMaze[row, col].S_wall = false;
                this.myMaze[nextRow, nextCol].N_wall = false;
            }
            int diffY = col - nextCol;
            if(diffY == 1) //Remove current's left and next right
            {
                this.myMaze[row, col].W_wall = false;
                this.myMaze[nextRow, nextCol].E_wall = false;
            }
            if (diffY == -1) //Remove current's right and next left
            {
                this.myMaze[row, col].E_wall = false;
                this.myMaze[nextRow, nextCol].W_wall = false;
            }
        }

        private void Dig(int row,int col, Stack<Tuple<int, int>> stack)
        { 

            this.myMaze[row, col].Visited = true;
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

        public void printCell(int row,int col)
        {

            if (this.myMaze[row, col].N_wall)
            {
            Console.SetCursorPosition(col * 4, (row * 4));
            Console.Write("*****");
            }
            if (this.myMaze[row, col].S_wall)
            {
                Console.SetCursorPosition(col * 4, ((row+1) *4));
                Console.Write("*****");
            }
            if (this.myMaze[row, col].W_wall)
            {
                for(int i = 0;i < 5; i++)
                {
                    Console.SetCursorPosition(col * 4, ((row*4)+i));
                        Console.Write("*");
                }
            }
            if (this.myMaze[row, col].E_wall)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.SetCursorPosition((col+1) * 4, ((row * 4) + i));
                    Console.Write("*");
                }
            }

        }
    }
}
