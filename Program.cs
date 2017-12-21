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
            Console.CursorVisible = false;
            Random mainRdm = new Random();
            List<Fighter> fighters = new List<Fighter>();
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
            fighters.Add(fighter);
            Thread.Sleep(500);
            Fighter fighter2 = new Fighter(false, myMaze, mainRdm.Next(height), mainRdm.Next(width), new Random());
            fighters.Add(fighter2);
            Thread.Sleep(200);
            Fighter fighter3 = new Fighter(false, myMaze, mainRdm.Next(height), mainRdm.Next(width), new Random());
            fighters.Add(fighter3);
            Thread.Sleep(200);
            Fighter fighter4 = new Fighter(false, myMaze, mainRdm.Next(height), mainRdm.Next(width), new Random());
            fighters.Add(fighter4);
            Thread.Sleep(200);
            Fighter fighter5 = new Fighter(false, myMaze, mainRdm.Next(height), mainRdm.Next(width), new Random());
            fighters.Add(fighter5);
            Thread.Sleep(1000);
            Voice voice = new Voice(fighters, myMaze, new Random());
            Console.ReadKey();
        }
    }
}
