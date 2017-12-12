using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyFights
{
    /*Une case qui n’est pas un mur peut être libre ou occupée. Une case occupée peut contenir
    soit un seul objet, soit un seul combattant (avec zéro ou plusieurs objets).*/
    class Cell
    {
        private bool n_wall;
        private bool s_wall;
        private bool e_wall;
        private bool w_wall;
        private int cellSize = 5;
        private bool visited;
        private Weapon weapon = null;

        public Cell()
        {
            this.n_wall = true;
            this.s_wall = true;
            this.e_wall = true;
            this.w_wall = true;
            this.visited = false;
        }
        #region Get/Set

        public bool N_wall
        {
            get
            {
                return n_wall;
            }

            set
            {
                n_wall = value;
            }
        }

        public bool S_wall
        {
            get
            {
                return s_wall;
            }

            set
            {
                s_wall = value;
            }
        }

        public bool E_wall
        {
            get
            {
                return e_wall;
            }

            set
            {
                e_wall = value;
            }
        }

        public bool W_wall
        {
            get
            {
                return w_wall;
            }

            set
            {
                w_wall = value;
            }
        }

        public int CellSize
        {
            get
            {
                return cellSize;
            }

            set
            {
                cellSize = value;
            }
        }

        public bool Visited
        {
            get
            {
                return visited;
            }

            set
            {
                visited = value;
            }
        }

        public Weapon Weapon
        {
            get
            {
                return weapon;
            }

            set
            {
                weapon = value;
            }
        }
        #endregion
    }
}
