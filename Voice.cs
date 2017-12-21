using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabyFights
{
    public class Voice
    {
        List<Fighter> fighters;
        Maze maze;
        Random rdm;
        public Voice(List<Fighter> fighters, Maze maze,Random rdm)
        {
            this.fighters = fighters;
            this.maze = maze;
            this.rdm = rdm;
            Thread threadVoice = new Thread(LaunchVoice);
            threadVoice.Start();
        }

        private void LaunchVoice()
        {
            while (true)
            {
                Thread.Sleep(rdm.Next(8000, 10000));
                List<Weapon> weaponList = new List<Weapon>();
                foreach(Fighter fighter in fighters)
                {
                    if(fighter.Equipement.Count != 0)
                    {
                        weaponList.AddRange(fighter.Equipement);

                    }
                    
                }
                maze.PlaceWeapons(weaponList);
            }
        }
    }
}
