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
        
        /// <summary>
        /// Constructeur de la classe Cell (Modèle)
        /// </summary>
        public Cell()
        {
            state = CellState.Dead;
        }

        /// <summary>
        /// Etat de la cellule
        /// </summary>
        public CellState State
        {
            get { return state; }
            set { state = value; }
        }
    }
}
