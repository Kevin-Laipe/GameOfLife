using GameOfLife.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.ViewModels
{
    /// <summary>
    /// Vue-Modèle d'une grille de Game Of Life
    /// </summary>
    class Grid : INotifyPropertyChanged
    {
        /*===============================*\
        |*           Attributs           *|
        \*===============================*/
        private Models.Grid model;
        private Cell[,] cells;

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
            this.model = new Models.Grid(width, height);

            cells = new Cell[model.Width, model.Height];
            for(int y = 0; y < model.Height; y++)
            {
                for(int x = 0; x < model.Width; x++)
                {
                    cells[x, y] = new Cell(model[x, y]);
                }
            }
        }

        /*===============================*\
        |*       Méthodes publiques      *|
        \*===============================*/

        /// <summary>
        /// Rempli la grille d'états aléatoires
        /// </summary>
        public void Randomize()
        {
            Clear(); //Nécéssaire pour que les statistiques soient corrects

            Random random = new Random(DateTime.Now.Millisecond);
            foreach(Cell cell in cells)
            {
                cell.State = (CellState)random.Next(0, 2);
            }
        }

        /// <summary>
        /// Met l'état de toutes les cellules de la grille à "mort"
        /// </summary>
        public void Clear()
        {
            foreach(Cell cell in cells)
            {
                cell.State = CellState.Dead;
            }

            Statistics.Reset();
        }

        /*===============================*\
        |*          Accesseurs           *|
        \*===============================*/

        /// <summary>
        /// Cellule de la grille
        /// </summary>
        /// <param name="x">Coordonée X de la cellule</param>
        /// <param name="y">Coordonée Y de la cellule</param>
        /// <returns></returns>
        public Cell this[int x, int y]
        {
            get { return cells[x, y]; }
            set
            {
                cells[x, y] = value;
                RaisePropertyChanged("Cell");
            }
        }

        /// <summary>
        /// Largeur (nombre de colonnes)
        /// </summary>
        public int Width
        {
            get { return model.Width; }
        }

        /// <summary>
        /// Hauter (nombre de lignes)
        /// </summary>
        public int Height
        {
            get { return model.Height; }
        }

        /// <summary>
        /// Statistiques liées à la grille
        /// </summary>
        public ViewModels.Statistics Statistics
        {
            get { return model.Statistics; }
            set { model.Statistics = value; }
        }

        /*===============================*\
        |*            Events             *|
        \*===============================*/
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Lève l'event PropertyChanger d'un attribut
        /// </summary>
        /// <param name="propertyName">Nom de l'attribut</param>
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
