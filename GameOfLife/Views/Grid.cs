using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;

namespace GameOfLife.Views
{
    class Grid : System.Windows.Controls.Grid
    {
        /*===============================*\
        |*           Attributs           *|
        \*===============================*/
        private ViewModels.Grid viewModel;
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
            RegisterEvents();

            this.VerticalAlignment = VerticalAlignment.Center;
            this.HorizontalAlignment = HorizontalAlignment.Center;
        }

        /*===============================*\
        |*       Méthodes privées        *|
        \*===============================*/

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
                    Cell newCell = new Cell(ViewModel[x, y]);
                    cells[x, y] = newCell;
                    this.Children.Add(newCell);
                    Grid.SetColumn(newCell, x);
                    Grid.SetRow(newCell, y);
                }
            }
        }

        private void RegisterEvents()
        {
            viewModel.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);
        }

        /*===============================*\
        |*      Méthodes publiques       *|
        \*===============================*/

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

        /*===============================*\
        |*            Events             *|
        \*===============================*/

        private void OnCellClicked()
        {

        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if(args.PropertyName == "Cell")
            {
                
            }
        }
    }
}
