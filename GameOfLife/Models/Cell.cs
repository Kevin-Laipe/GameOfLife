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
        private CellState nextState;
        private int age;
        private int x;
        private int y;

        /*===============================*\
        |*        Constructeurs          *|
        \*===============================*/

        public Cell(int x, int y)
        {
            state = CellState.Dead;
            nextState = CellState.Dead;
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
