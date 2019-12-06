using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    class Cell
    {
        public enum CellState { Alive, Dead}

        private CellState state;
        
        public Cell()
        {
            state = CellState.Dead;
        }

        public CellState State
        {
            get { return state; }
            set { state = value; }
        }
    }
}
