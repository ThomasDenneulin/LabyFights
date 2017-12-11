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
            int width = 15;
            int height = 10;
            Console.SetWindowSize(width*4,height*4);
            Maze myMaze = new Maze(width,height,new Random());
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
