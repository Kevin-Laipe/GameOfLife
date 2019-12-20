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

        /*===============================*\
        |*        Constructeurs          *|
        \*===============================*/

        public Cell()
        {
            state = CellState.Dead;
            age = 0;
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
    }
}
