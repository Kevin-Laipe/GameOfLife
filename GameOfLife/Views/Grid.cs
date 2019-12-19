using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace GameOfLife.Views
{
    class Grid : System.Windows.Controls.Grid
    {
        //Attributs
        private ViewModels.Grid viewModel;
        private Cell[,] cells;

        /// <summary>
        /// Constructeur de la classe Grid (View)
        /// </summary>
        /// <param name="model">Modèle de la grille</param>
        public Grid() : this(10, 10)
        {

        }

        public Grid(int width, int height)
        {
            this.viewModel = new ViewModels.Grid(width, height);
            cells = new Cell[viewModel.Width, viewModel.Height];

            Init();
            this.VerticalAlignment = VerticalAlignment.Center;
            this.HorizontalAlignment = HorizontalAlignment.Center;
        }

        /// <summary>
        /// Initialisation de la grille
        /// </summary>
        private void Init()
        {
            for(int x = 0; x < viewModel.Width; x++)
            {
                this.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for(int y = 0; y < viewModel.Height; y++)
            {
                this.RowDefinitions.Add(new RowDefinition());
            }

            for(int y = 0; y < viewModel.Height; y++)
            {
                for(int x = 0; x < viewModel.Width; x++)
                {
                    //Création des cellules et ajout à la grille
                    Cell newCell = new Cell(viewModel[x, y]);
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
                cell.Background = cell.ViewModel.GetColor();
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
            Grid newGrid = new Grid(rows, columns);

            for(int y = 0; y < viewModel.Height; y++)
            {
                for(int x = 0; x < viewModel.Width; x++)
                {
                    if(x < newGrid.ViewModel.Width && y < newGrid.ViewModel.Height)
                        newGrid.viewModel[x, y].State = viewModel[x, y].State;
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
            double horizontal_size = width / viewModel.Width;
            double vertical_size = height / viewModel.Height;

            double size = (horizontal_size < vertical_size) ? horizontal_size : vertical_size;

            this.Width = size * viewModel.Width;
            this.Height = size * viewModel.Height;
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
        public ViewModels.Grid ViewModel
        {
            get { return viewModel; }
        }
    }
}
