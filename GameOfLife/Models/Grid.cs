using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    class Grid
    {
        //Attributs
        private Cell[,] cells;
        private int height, width;
        private Statistics statistics;

        /// <summary>
        /// Constructeur de la classe Grid (Modèle)
        /// </summary>
        /// <param name="width">Nombre de colonne</param>
        /// <param name="height">Nombre de ligne</param>
        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;
            statistics = new Statistics();

            this.InitCells(width, height);
        }

        /// <summary>
        /// Créer une grille avec des cellules d'état aléatoire
        /// </summary>
        public void Randomize()
        {
            statistics.Reset();

            Random random = new Random();
            foreach (Cell cell in cells)
            {
                cell.State = (Cell.CellState)random.Next(0, 2);

                if (cell.State == Cell.CellState.Alive)
                    statistics.population += 1;
            }

            statistics.smallestPopulation = statistics.population;
            statistics.greatestPopulation = statistics.population;
        }

        /// <summary>
        /// Met toutes les valeurs des cellule à Mort
        /// </summary>
        public void Clear()
        {
            statistics.Reset();

            foreach(Cell cell in cells)
            {
                cell.State = Cell.CellState.Dead;
            }
        }

        /// <summary>
        /// Crée le tableau de cellules
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void InitCells(int width, int height)
        {
            this.cells = new Cell[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[x, y] = new Cell();
                }
            }
        }

        /// <summary>
        /// Cellule de la grille
        /// </summary>
        /// <param name="x">Collone de la cellule</param>
        /// <param name="y">Ligne de la cellule</param>
        /// <returns></returns>
        public Cell this[int x, int y]
        {
            get { return cells[x, y]; }
            set { cells[x, y] = value; }
        }

        /// <summary>
        /// Nombre de collone
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// Nombre de ligne
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Statistiques liées à la grille
        /// </summary>
        public Statistics Statistics
        {
            get { return statistics; }
        }

    }
}
