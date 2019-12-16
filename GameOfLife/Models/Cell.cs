using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    class Cell
    {
        /// <summary>
        /// Etats possibles d'une cellule
        /// </summary>
        public enum CellState { Alive, Dead}

        //Attributs
        private CellState state;
        private CellState nextState;
        private int age;
        
        /// <summary>
        /// Constructeur de la classe Cell (Modèle)
        /// </summary>
        public Cell()
        {
            state = CellState.Dead;
            nextState = CellState.Dead;
            age = 0;
        }

        public void Prepare(CellState nextState)
        {
            this.nextState = nextState;
        }

        public void Apply()
        {
            state = nextState;

            if (state == CellState.Dead)
                age = 0;
            else
                age++;
        }

        /// <summary>
        /// Etat de la cellule
        /// </summary>
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
