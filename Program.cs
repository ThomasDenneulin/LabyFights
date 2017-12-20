using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabyFights
{
    class Program
    {
        static void Main(string[] args)
        {
            Random mainRdm = new Random();
            int width = 15;
            int height = 10;
            Console.SetWindowSize((width*4)+2,(height*4)+2);
            Maze myMaze = new Maze(width,height,new Random());
            Console.Clear();
            for(int i = 0; i < myMaze.MyMaze.GetLength(0);i++)
            {
                for(int j = 0; j < myMaze.MyMaze.GetLength(1);j++)
                {
                    myMaze.printCell(i, j);
                }
            }
            Thread.Sleep(2000);
            Fighter fighter = new Fighter(false, myMaze, 1, 1, new Random());
            Thread.Sleep(500);
            Fighter fighter2 = new Fighter(false, myMaze, mainRdm.Next(height), mainRdm.Next(width), new Random());
            Thread.Sleep(200);
            Fighter fighter3 = new Fighter(false, myMaze, mainRdm.Next(height), mainRdm.Next(width), new Random());
            Thread.Sleep(200);
            Fighter fighter4 = new Fighter(false, myMaze, mainRdm.Next(height), mainRdm.Next(width), new Random());
            Thread.Sleep(200);
            Fighter fighter5 = new Fighter(false, myMaze, mainRdm.Next(height), mainRdm.Next(width), new Random());
            Console.ReadKey();
        }
    }
}
