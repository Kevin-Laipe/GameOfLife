using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.ViewModels
{
    class Statistics : INotifyPropertyChanged
    {
        //Attributs
        private Models.Statistics model;

        //Events
        public event PropertyChangedEventHandler PropertyChanged;

        public Statistics()
        {
            model = new Models.Statistics();
        }

        public int Iterations
        {
            get { return model.iterations; }
            set
            {
                model.iterations = value;
                RaisePropertyChanged("Iterations");
            }
        }

        public int Population
        {
            get { return model.population; }
            set
            {
                model.population = value;
                RaisePropertyChanged("Population");
            }
        }

        public int GreatestPopulation
        {
            get { return model.greatestPopulation; }
            set
            {
                model.greatestPopulation = value;
                RaisePropertyChanged("GreatestPopulation");
            }
        }

        public int SmallestPopulation
        {
            get { return model.smallestPopulation; }
            set
            {
                model.smallestPopulation = value;
                RaisePropertyChanged("SmallestPopulation");
            }
        }

        public int OldestCell
        {
            get { return model.oldestCell; }
            set
            {
                model.oldestCell = value;
                RaisePropertyChanged("OldestCell");
            }
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
