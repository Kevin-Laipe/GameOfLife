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
        /*===============================*\
        |*           Attributs           *|
        \*===============================*/
        Models.Cell model;

        /*===============================*\
        |*        Constructeurs          *|
        \*===============================*/

        public Cell(Models.Cell model)
        {
            this.model = model;
        }

        /*===============================*\
        |*      Méthodes publiques       *|
        \*===============================*/

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

        /*===============================*\
        |*           Accesseurs          *|
        \*===============================*/
        private CellState nextState;

        public void Prepare(CellState nextState)
        {
            this.nextState = nextState;   
        }

        public void Apply()
        {
            if(nextState != null)
            {
                this.State = nextState;
            }
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

        public int X
        {
            get { return model.X; }
            set { model.X = value; }
        }

        public int Y
        {
            get { return model.Y; }
            set { model.Y = value; }
        }

        /*===============================*\
        |*            Events             *|
        \*===============================*/

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
