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
        private bool n_Wall;
        private bool s_Wall;
        private bool e_wall;
        private bool w_wall;
        private int cellSize = 5;
        private bool visited;

        public Cell()
        {
            this.n_Wall = true;
            this.s_Wall = true;
            this.e_wall = true;
            this.w_wall = true;
            this.visited = false;
        }
        #region Get/Set

        public bool N_Wall
        {
            get
            {
                return n_Wall;
            }

            set
            {
                n_Wall = value;
            }
        }

        public bool S_Wall
        {
            get
            {
                return s_Wall;
            }

            set
            {
                s_Wall = value;
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
        #endregion
    }
}
