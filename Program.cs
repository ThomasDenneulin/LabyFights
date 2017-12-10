using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyFights
{
    class Program
    {
        static void Main(string[] args)
        {
            Maze myMaze = new Maze(10, 10,new Random());
            Console.Clear();
            for(int i = 0; i < myMaze.MyMaze.GetLength(0);i++)
            {
                for(int j = 0; j < myMaze.MyMaze.GetLength(1);j++)
                {
                    myMaze.printCell(i, j);
                }
            }
            Console.ReadKey();
        }
    }
}
