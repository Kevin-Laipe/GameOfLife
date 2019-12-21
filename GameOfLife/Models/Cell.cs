using GameOfLife.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
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

        public CellState State
        {
            get { return state; }
            set { state = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
