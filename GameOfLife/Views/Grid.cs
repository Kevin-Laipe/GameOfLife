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

        public Grid() : this(10, 10) { }

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

        public Grid Resize(int rows, int columns)
        {
            Grid newGrid = new Grid(rows, columns);
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

        public void ChangeSize(double width, double height)
        {
            double horizontal_size = width / viewModel.Width;
            double vertical_size = height / viewModel.Height;

            double size = (horizontal_size < vertical_size) ? horizontal_size : vertical_size;

            this.Width = size * viewModel.Width;
            this.Height = size * viewModel.Height;
        }

        /*===============================*\
        |*           Accesseurs          *|
        \*===============================*/

        private Cell this[int x, int y]
        {
            get { return cells[x, y]; }
        }

        public ViewModels.Grid ViewModel
        {
            get { return viewModel; }
        }

        public ViewModels.Statistics Statistics
        {
            get { return viewModel.Statistics; }
            set { viewModel.Statistics = value; }
        }

        public void SetPatterns(ViewModels.Pattern patterns)
        {
            this.patterns = patterns;
        }

        /*===============================*\
        |*            Events             *|
        \*===============================*/

        private void OnCellPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            ViewModels.Cell cell = sender as ViewModels.Cell;

            switch (args.PropertyName)
            {
                case "State":
                    if (cell.State == CellState.Alive)
                        Statistics.Population += 1;
                    else
                        Statistics.Population -= 1;
                    break;

                case "Age":
                    if (cell.Age > Statistics.OldestCell)
                        Statistics.OldestCell = cell.Age;
                    break;

            }

            
        }

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
