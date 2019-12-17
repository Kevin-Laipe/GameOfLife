using System;
using System.Windows.Controls;
using System.Windows;

namespace GameOfLife.Views
{
    class Grid : System.Windows.Controls.Grid
    {
        private Models.Grid model;
        private Cell[,] cells;

        /// <summary>
        /// Constructeur de la classe Grid (View)
        /// </summary>
        /// <param name="model">Modèle de la grille</param>
        public Grid(Models.Grid model)
        {
            this.model = model;
            cells = new Cell[model.Width, model.Height];

            Init();
        }

        /// <summary>
        /// Initialisation de la grille
        /// </summary>
        private void Init()
        {
            for(int x = 0; x < model.Width; x++)
            {
                this.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for(int y = 0; y < model.Height; y++)
            {
                this.RowDefinitions.Add(new RowDefinition());
            }

            for(int y = 0; y < model.Height; y++)
            {
                for(int x = 0; x < model.Width; x++)
                {
                    //Création des cellules et ajout à la grille
                    Cell newCell = new Cell(model[x, y], model.Statistics);
                    cells[x, y] = newCell;
                    this.Children.Add(newCell);
                    Grid.SetColumn(newCell, x);
                    Grid.SetRow(newCell, y);
                }
            }
        }

        /// <summary>
        /// Met à jour les couleurs des cellules
        /// </summary>
        public void Refresh()
        {
            foreach(Cell cell in cells)
            {
                cell.UpdateColor();
            }
        }

        /// <summary>
        /// Modifie le nombre de lignes et de colonnes de la grille
        /// </summary>
        /// <param name="rows">Nombre de lignes</param>
        /// <param name="columns">Nombre de colonnes</param>
        /// <returns>Grille redimensionnée</returns>
        public Grid Resize(int rows, int columns)
        {
            Grid newGrid = new Grid(new Models.Grid(rows, columns));

            for(int y = 0; y < model.Height; y++)
            {
                for(int x = 0; x < model.Width; x++)
                {
                    if(x < newGrid.Model.Width && y < newGrid.Model.Height)
                        newGrid.model[x, y].State = model[x, y].State;
                }
            }

            return newGrid;
        }

        /// <summary>
        /// Redimensionne (pixel) la taille de la grille.
        /// </summary>
        /// <param name="width">Lageur de la grille (pixel)</param>
        /// <param name="height">Hauteur de la grille (pixel)</param>
        public void ChangeSize(double width, double height)
        {
            double horizontal_size = width / model.Width;
            double vertical_size = height / model.Height;

            double size = (horizontal_size < vertical_size) ? horizontal_size : vertical_size;

            this.Width = size * model.Width;
            this.Height = size * model.Height;
        }

        /// <summary>
        /// Cellule de la grille
        /// </summary>
        /// <param name="x">Colonne de la cellule</param>
        /// <param name="y">Ligne de la cellule</param>
        /// <returns></returns>
        private Cell this[int x, int y]
        {
            get { return cells[x, y]; }
        }

        /// <summary>
        /// Modèle représentant la grille
        /// </summary>
        public Models.Grid Model
        {
            get { return model; }
        }
    }
}
