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

            RegisterEvents();
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
                    Cell newCell = new Cell(model[x, y]);
                    cells[x, y] = newCell;
                    this.Children.Add(newCell);
                    Grid.SetRow(newCell, x);
                    Grid.SetColumn(newCell, y);
                }
            }
        }

        /// <summary>
        /// Ajoute tous le événement de cet objet
        /// </summary>
        private void RegisterEvents()
        {
            //this.SizeChanged += new SizeChangedEventHandler(OnSizeChanged);
        }

        /// <summary>
        /// Méthode appelée lorsque la dimension de la grille est modifiée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnSizeChanged(Object sender, SizeChangedEventArgs args)
        {
            if(args.NewSize.Width >= 1 && args.NewSize.Height >= 1)
            {
                double cellWidth = (args.NewSize.Width - 1) / model.Width;
                double cellHeight = (args.NewSize.Height - 1) / model.Height;
                double cellSize = (cellWidth < cellHeight) ? cellWidth : cellHeight;

                this.Width = cellSize * model.Width;
                this.Height = cellSize * model.Height;

                foreach (Cell cell in cells)
                {
                    cell.Width = cellSize;
                    cell.Height = cellSize;
                }
            }
        }

        /// <summary>
        /// Cellule de la grulle
        /// </summary>
        /// <param name="x">Colonne de la cellule</param>
        /// <param name="y">Ligne de la cellule</param>
        /// <returns></returns>
        private Cell this[int x, int y]
        {
            get { return cells[x, y]; }
        }
    }
}
