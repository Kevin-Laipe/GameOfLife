using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    /// <summary>
    /// Modèle de statistiques d'une grille de Game Of Life
    /// </summary>
    class Statistics
    {
       /*===============================*\
       |*           Attributs           *|
       \*===============================*/
        private int iterations;
        private int population;
        private int greatestPopulation;
        private int smallestPopulation;
        private int oldestCell;

       /*===============================*\
       |*         Constructeurs         *|
       \*===============================*/

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Statistics()
        {
            iterations = 0;
            population = 0;
            greatestPopulation = 0;
            smallestPopulation = 0;
            oldestCell = 0;
        }

       /*===============================*\
       |*          Accesseurs           *|
       \*===============================*/

        /// <summary>
        /// Nombre d'itérations
        /// </summary>
        public int Iterations
        {
            get { return iterations; }
            set { iterations = value; }
        }

        /// <summary>
        /// Population actuelle
        /// </summary>
        public int Population
        {
            get { return population; }
            set { population = value; }
        }

        /// <summary>
        /// Population minimale
        /// </summary>
        public int GreatestPopulation
        {
            get { return greatestPopulation; }
            set { greatestPopulation = value; }
        }

        /// <summary>
        /// Population maximale
        /// </summary>
        public int SmallestPopulation
        {
            get { return smallestPopulation; }
            set { smallestPopulation = value; }
        }

        /// <summary>
        /// Age de la cellule la plus vielle
        /// </summary>
        public int OldestCell
        {
            get { return oldestCell; }
            set { oldestCell = value; }
        }
    }
}
