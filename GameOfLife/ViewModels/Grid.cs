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
        //Attributs
        private Models.Grid model;
        private Cell[,] cells;

        //Events
        public event PropertyChangedEventHandler PropertyChanged;

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

        public void Randomize()
        {
            model.Randomize();
        }

        public void Clear()
        {
            model.Clear();
        }

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

        public Models.Statistics Statistics
        {
            get { return model.Statistics; }
        }

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
