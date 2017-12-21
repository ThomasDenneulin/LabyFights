using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyFights
{
    /*Le labyrinthe est une entité unique, jouant le rôle d’élément central. Il est de forme
    rectangulaire entièrement entouré de murs. Les murs et la sortie sont des cases particulières*/
    public class Maze
    {
        private Cell[,] myMaze;
        private int width;
        private int height;
        Random rdm;
        Tuple<int, int> exit;
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

        public Tuple<int, int> Exit
        {
            get
            {
                return exit;
            }

            set
            {
                exit = value;
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
            DigExit();
            InitWeapons();
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

        /// <summary>
        /// Backtracking recursif algo
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="stack"></param>
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

        /// <summary>
        /// En début de programme, les objets occupent environ 10% des cases libres et y sontplacés aléatoirement.
        /// </summary>
        private void InitWeapons()
        {
            Random random = new Random();
            int nbCellRequired = Convert.ToInt32((this.width * this.height) * 0.1);
            while(nbCellRequired > 0)
            {
                int row = random.Next(this.height);
                int col = random.Next(this.width);
                if (this.myMaze[row, col].Weapon == null && !this.myMaze[row,col].Exit)
                {
                    myMaze[row, col].Weapon = new Weapon(random.Next(1,11));
                    nbCellRequired -= 1;
                }
            }
        }

        /// <summary>
        /// Place la liste d'armes aléatoirement sur le laby
        /// </summary>
        /// <param name="weapons"></param>
        public void PlaceWeapons(List<Weapon> weapons)
        {
            Random random = new Random();
            while (weapons.Count > 0)
            {
                int row = random.Next(this.height);
                int col = random.Next(this.width);
                if (this.myMaze[row, col].Weapon == null && !this.myMaze[row, col].Exit && !this.myMaze[row, col].Fighter)
                {
                    myMaze[row, col].Weapon = weapons[0];
                    weapons.Remove(weapons[0]);
                    printCell(row, col);
                }
            }
        }

        /// <summary>
        /// Dig an exit at a random pos
        /// </summary>
        private void DigExit()
        {
            int row = rdm.Next(this.height);
            int col = rdm.Next(this.width);
            myMaze[row, col].Exit = true;
            this.exit = Tuple.Create(row, col);
        }

        public void printCell(int row,int col)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorVisible = false;
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

            if(this.myMaze[row,col].Weapon != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition((col * 4)+2, (row * 4)+2);
                Console.Write(this.myMaze[row, col].Weapon.Damage);
            }
            else if (this.myMaze[row, col].Exit)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition((col * 4) + 2, (row * 4) + 2);
                Console.Write("*");
            }
            if (this.myMaze[row, col].Fighter)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition((col * 4) + 2, (row * 4) + 2);
                Console.Write("O");
            }
            if(!this.myMaze[row, col].Fighter && !this.myMaze[row,col].Exit && this.myMaze[row,col].Weapon == null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition((col * 4) + 2, (row * 4) + 2);
                Console.Write(" ");
            }

        }
    }
}
