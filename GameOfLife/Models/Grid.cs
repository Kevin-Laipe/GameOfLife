using GameOfLife.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    class Grid
    {
        /*===============================*\
        |*           Attributs           *|
        \*===============================*/
        private Cell[,] cells;
        private int height, width;
        private ViewModels.Statistics statistics;

        /*===============================*\
        |*         Constructeurs         *|
        \*===============================*/

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="width">Largeur (nombre de colonnes)</param>
        /// <param name="height">Hauteur (nombre de lignes)</param>
        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;

            statistics = new ViewModels.Statistics();
            this.InitCells(width, height);
        }

        /*===============================*\
        |*       Méthodes privées        *|
        \*===============================*/

        private void InitCells(int width, int height)
        {
            this.cells = new Cell[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[x, y] = new Cell(x, y);
                }
            }
        }

        /*===============================*\
        |*           Accesseurs          *|
        \*===============================*/

        /// <summary>
        /// Cellule aux coordonnées spécifiées
        /// </summary>
        /// <param name="x">Coordonée X</param>
        /// <param name="y">Coordonée Y</param>
        /// <returns>Cellule</returns>
        public Cell this[int x, int y]
        {
            get { return cells[x, y]; }
            set { cells[x, y] = value; }
        }

        /// <summary>
        /// Largeur (nombre de colonnes) de la grille
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// Hauteur (nombre de lignes) de la grille
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Statistiques liées à la grille
        /// </summary>
        public ViewModels.Statistics Statistics
        {
            get { return statistics; }
            set { statistics = value; }
        }
    }
}
