using GameOfLife.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    /// <summary>
    /// Modèle d'une cellule de Game Of Life
    /// </summary>
    class Cell
    {
        /*===============================*\
        |*           Attributs           *|
        \*===============================*/
        private CellState state;
        private int age;
        private int x;
        private int y;

        /*===============================*\
        |*        Constructeurs          *|
        \*===============================*/

        public Cell() : this(0, 0) { }

        public Cell(int x, int y)
        {
            state = CellState.Dead;
            age = 0;
            this.x = x;
            this.y = y;
        }

        /*===============================*\
        |*          Accesseurs           *|
        \*===============================*/

        /// <summary>
        /// Etat de la cellule
        /// </summary>
        public CellState State
        {
            get { return state; }
            set { state = value; }
        }

        /// <summary>
        /// Age de la cellule
        /// </summary>
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        /// <summary>
        /// Position x de la cellule
        /// </summary>
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// Positition y de la cellule
        /// </summary>
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
