using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabyFights
{
    public class Fighter
    {
        int lifePoint;
        int damage;
        bool aggressif;
        Maze maze;
        int currentRow;
        int currentCol;
        List<Weapon> equipement;
        List<Tuple<int, int>> visited;
        Stack<Tuple<int, int>> visitedCell; //Backtracking
        Random rdm;

        public Fighter(bool aggressif, Maze maze, int row, int col,Random rdm)
        {
            this.equipement = new List<Weapon>();
            this.lifePoint = 100;
            this.damage = 10;
            this.aggressif = aggressif;
            this.maze = maze;
            this.currentCol = col;
            this.currentRow = row;
            this.rdm = rdm;
            this.maze.MyMaze[row, col].Fighter = true;
            this.maze.printCell(row, col);
            Thread threadWhosMovingFighter = new Thread(Move);
            threadWhosMovingFighter.Start();

        }

        private void Move()
        {
            Thread.Sleep(1000);
            InitVisitedCell();
            visited = new List<Tuple<int, int>>();
            visitedCell = new Stack<Tuple<int, int>>();
            while(currentRow != this.maze.Exit.Item1 || currentCol != this.maze.Exit.Item2)
            {
                if(maze.MyMaze[currentRow,currentCol].Weapon != null)
                {
                    this.equipement.Add(maze.MyMaze[currentRow, currentCol].Weapon);
                    maze.MyMaze[currentRow, currentCol].Weapon = null;
                }
                //maze.MyMaze[currentRow, currentCol].Visited = true; //Make this cell as visited
                visited.Add(Tuple.Create(currentRow, currentCol));
                Tuple<int,int> nextCell = RandomAdjCell(); //Select a random cell
                if(nextCell.Item1 != -1) //If a adj cell has not beed visited
                {
                    //Remove the player from actual cell
                    maze.MyMaze[currentRow, currentCol].Fighter = false;
                    maze.printCell(currentRow, currentCol);
                    //Add actual cell as a visitedCell;
                    visitedCell.Push(Tuple.Create(currentRow, currentCol));
                    currentRow = nextCell.Item1;
                    currentCol = nextCell.Item2;
                    //Add the player on next random adj cell
                    maze.MyMaze[currentRow, currentCol].Fighter = true;
                    maze.printCell(currentRow, currentCol);
                }
                else 
                {
                    //Remove the player from actual cell
                    maze.MyMaze[currentRow, currentCol].Fighter = false;
                    maze.printCell(currentRow, currentCol);
                    //Dequeu the path
                    Tuple<int, int> previousCell = visitedCell.Pop();
                    currentRow = previousCell.Item1;
                    currentCol = previousCell.Item2;
                    //Add the player on next random adj cell
                    maze.MyMaze[currentRow, currentCol].Fighter = true;
                    maze.printCell(currentRow, currentCol);
                }
                Thread.Sleep(1000);
            }
        }

        private void InitVisitedCell()
        {
            for(int row = 0; row < maze.MyMaze.GetLength(0);row++)
            {
                for (int col = 0; col < maze.MyMaze.GetLength(1);col++)
                {
                    maze.MyMaze[row, col].Visited = false;
                }
            }
        }

        /// <summary>
        /// Fonction qui définie la logique de déplacement du personnage
        ///
        /// </summary>
        /// <returns></returns>
        private Tuple<int,int> RandomAdjCell()
        {
            List <Tuple<int, int>> myList = new List<Tuple<int, int>>();

            if (currentRow > 0 && !visited.Contains(Tuple.Create(currentRow-1,currentCol)) && !maze.MyMaze[currentRow,currentCol].N_wall)//North neighbour
            {
                myList.Add(Tuple.Create(currentRow - 1, currentCol));
            }
            if (currentRow < this.maze.MyMaze.GetLength(0) - 1 && !visited.Contains(Tuple.Create(currentRow + 1, currentCol)) && !maze.MyMaze[currentRow, currentCol].S_wall) //South neighbour
            {
                myList.Add(Tuple.Create(currentRow + 1, currentCol));
            }
            if (currentCol > 0 && !visited.Contains(Tuple.Create(currentRow, currentCol-1)) && !maze.MyMaze[currentRow, currentCol].W_wall) //West neighbour
            {
                myList.Add(Tuple.Create(currentRow, currentCol - 1));
            }
            if (currentCol < this.maze.MyMaze.GetLength(1) - 1 && !visited.Contains(Tuple.Create(currentRow, currentCol+1)) && !maze.MyMaze[currentRow, currentCol].E_wall) //East neigbour
            {
                myList.Add(Tuple.Create(currentRow, currentCol + 1));
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

        public List<Weapon> Equipement
        {
            get
            {
                return equipement;
            }

            set
            {
                equipement = value;
            }
        }
    }
}
