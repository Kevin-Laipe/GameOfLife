using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;
using System.Diagnostics;
using GameOfLife.Enums;
using GameOfLife.Models;

namespace GameOfLife.Views
{
    /// <summary>
    /// Vue d'une grille de Game Of Life
    /// </summary>
    class Grid : System.Windows.Controls.Grid
    {
        /*===============================*\
        |*           Attributs           *|
        \*===============================*/
        private ViewModels.Grid viewModel;
        private ViewModels.Pattern patterns;
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
            this.viewModel = new ViewModels.Grid(width, height);
            cells = new Cell[viewModel.Width, viewModel.Height];

            Init();

            this.VerticalAlignment = VerticalAlignment.Center;
            this.HorizontalAlignment = HorizontalAlignment.Center;
        }

        /*===============================*\
        |*       Méthodes privées        *|
        \*===============================*/

        /// <summary>
        /// Initialise la grille
        /// </summary>
        private void Init()
        {
            for (int x = 0; x < viewModel.Width; x++)
            {
                this.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int y = 0; y < viewModel.Height; y++)
            {
                this.RowDefinitions.Add(new RowDefinition());
            }

            for (int y = 0; y < viewModel.Height; y++)
            {
                for (int x = 0; x < viewModel.Width; x++)
                {
                    Cell newCell = new Cell(ViewModel[x, y]);
                    cells[x, y] = newCell;
                    newCell.Click += new RoutedEventHandler(OnCellClicked);
                    newCell.ViewModel.PropertyChanged += new PropertyChangedEventHandler(OnCellPropertyChanged);
                    this.Children.Add(newCell);
                    Grid.SetColumn(newCell, x);
                    Grid.SetRow(newCell, y);
                }
            }
        }

        /*===============================*\
        |*      Méthodes publiques       *|
        \*===============================*/

        /// <summary>
        /// Retourne une grille redimentionnée contenant les mêmes valeurs et les mêmes statistiques que celle-ci
        /// 
        /// /!\ A ne pas confondre avec ChangeSize !!
        /// </summary>
        /// <param name="width">Largeur (nombre de colonnes) de la nouvelle grille</param>
        /// <param name="height">Hauteur (nombre de lignes) de la nouvelle grille</param>
        /// <returns>Grille redimensionnée</returns>
        public Grid Resize(int width, int height)
        {
            Grid newGrid = new Grid(width, height);
            newGrid.Statistics = this.Statistics;

            for (int y = 0; y < viewModel.Height; y++)
            {
                for (int x = 0; x < viewModel.Width; x++)
                {
                    if (x < newGrid.ViewModel.Width && y < newGrid.ViewModel.Height)
                        newGrid.viewModel[x, y].State = viewModel[x, y].State;
                }
            }

            return newGrid;
        }

        /// <summary>
        /// Modifie la taille de la grille (pixel)
        /// 
        /// /!\ A ne pas confondre avec Resize !!
        /// </summary>
        /// <param name="width">Largeur disponible</param>
        /// <param name="height">Hauteur disponible</param>
        public void ChangeSize(double width, double height)
        {
            double horizontal_size = width / viewModel.Width;
            double vertical_size = height / viewModel.Height;

            double size = (horizontal_size < vertical_size) ? horizontal_size : vertical_size;

            this.Width = size * viewModel.Width;
            this.Height = size * viewModel.Height;
        }

        /*===============================*\
        |*       Méthodes publiques      *|
        \*===============================*/

        /// <summary>
        /// Enregistre la Vue-Modèle des patterns
        /// </summary>
        /// <param name="patterns"></param>
        public void SetPatterns(ViewModels.Pattern patterns)
        {
            this.patterns = patterns;
        }

        /*===============================*\
        |*           Accesseurs          *|
        \*===============================*/

        /// <summary>
        /// Cellule de la grille
        /// </summary>
        /// <param name="x">Coodonée X de la cellule</param>
        /// <param name="y">Coordonée Y de la cellule</param>
        /// <returns>Cellule</returns>
        private Cell this[int x, int y]
        {
            get { return cells[x, y]; }
        }

        /// <summary>
        /// Vue-Modèle de la grille
        /// </summary>
        public ViewModels.Grid ViewModel
        {
            get { return viewModel; }
        }

        /// <summary>
        /// Statistiques de la grilles
        /// </summary>
        public ViewModels.Statistics Statistics
        {
            get { return viewModel.Statistics; }
            set { viewModel.Statistics = value; }
        }

        /*===============================*\
        |*            Events             *|
        \*===============================*/

        /// <summary>
        /// Méthode appelé lorsque un propriété d'une cellule est modifiée
        /// </summary>
        /// <param name="sender">Envoyeur de l'event</param>
        /// <param name="args">Arguments de l'event</param>
        private void OnCellPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            ViewModels.Cell cell = sender as ViewModels.Cell;

            switch (args.PropertyName)
            {
                //Si c'est l'état de la cellule qui a été modifié
                case "State":
                    if (cell.State == CellState.Alive)
                        Statistics.Population += 1;
                    else
                        Statistics.Population -= 1;
                    break;

                //Si c'est l'age de la cellule qui a été modifié
                case "Age":
                    if (cell.Age > Statistics.OldestCell)
                        Statistics.OldestCell = cell.Age;
                    break;

            }           
        }

        /// <summary>
        /// Méthode appelée lorsque une des cellule de la grille est clickée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnCellClicked(object sender, RoutedEventArgs args)
        {
            if(patterns != null)
            {
                Pattern currentPattern = patterns.SelectedPattern;
                Cell cellClicked = sender as Cell;

                foreach (Point point in currentPattern.Cells)
                {
                    int x = (int) (cellClicked.ViewModel.X + point.X);
                    int y = (int) (cellClicked.ViewModel.Y + point.Y);
                    Cell cell = cells[x % viewModel.Width, y % viewModel.Height];

                    cell.ViewModel.State = CellState.Alive;
                }
            }
        }
    }
}
