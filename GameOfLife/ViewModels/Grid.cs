using GameOfLife.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.ViewModels
{
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

        public void Randomize()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            foreach(Cell cell in cells)
            {
                cell.State = (CellState)random.Next(0, 2);
            }
        }

        public void Clear()
        {
            foreach(Cell cell in cells)
            {
                cell.State = CellState.Dead;
            }
        }

        /*===============================*\
        |*          Accesseurs           *|
        \*===============================*/

        public Cell this[int x, int y]
        {
            get { return cells[x, y]; }
            set
            {
                cells[x, y] = value;
                RaisePropertyChanged("Cell");
            }
        }

        public int Width
        {
            get { return model.Width; }
        }

        public int Height
        {
            get { return model.Height; }
        }

        public ViewModels.Statistics Statistics
        {
            get { return model.Statistics; }
            set { model.Statistics = value; }
        }

        /*===============================*\
        |*            Events             *|
        \*===============================*/
        public event PropertyChangedEventHandler PropertyChanged;

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
