using GameOfLife.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GameOfLife.ViewModels
{
    class Cell : INotifyPropertyChanged
    {
        //Attributs
        Models.Cell model;

        public Cell(Models.Cell model)
        {
            this.model = model;
        }

        public Brush GetColor()
        {
            switch(model.State)
            {
                case CellState.Alive:
                    return Brushes.Green;

                case CellState.Dead:
                default:
                    return Brushes.Transparent;
            }
        }

        public void Prepare(CellState nextState)
        {
            model.Prepare(nextState);
        }

        public void Apply()
        {
            model.Apply();
        }

        public CellState State
        {
            get { return model.State; }
            set
            {
                model.State = value;
                RaisePropertyChanged("State");
            }
        }

        public int Age
        {
            get { return model.Age; }
        }

        //Events
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
