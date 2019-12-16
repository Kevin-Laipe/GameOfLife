using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    class Statistics
    {
        /// <summary>
        /// Population actuelle de la grille
        /// </summary>
        public int population;

        /// <summary>
        /// Nombre d'itérations éffectuées
        /// </summary>
        public int iterations;

        /// <summary>
        /// Plus petite population
        /// </summary>
        public int smallestPopulation;

        /// <summary>
        /// Plus grande population
        /// </summary>
        public int greatestPopulation;

        /// <summary>
        /// Age de la cellule la plus vielle
        /// </summary>
        public int oldestCell;

        public Statistics()
        {
            Reset();
        }

        /// <summary>
        /// Remet à zéro toutes les valeurs
        /// </summary>
        public void Reset()
        {
            population = 0;
            iterations = 0;
            smallestPopulation = 0;
            greatestPopulation = 0;
            oldestCell = 0;
        }
    }
}
