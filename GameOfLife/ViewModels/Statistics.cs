﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.ViewModels
{
    class Statistics : INotifyPropertyChanged
    {
        private Models.Statistics model;

        public Statistics()
        {
            this.model = new Models.Statistics();
        }

        public int Iterations
        {
            get { return model.Iterations; }
            set
            {
                model.Iterations = value;
                RaisePropertyChanged("Iterations");
            }
        }

        public int Population
        {
            get { return model.Population; }
            set
            {
                model.Population = value;
                RaisePropertyChanged("Population");
            }
        }

        public int GreatestPopulation
        {
            get { return model.GreatestPopulation; }
            set
            {
                model.GreatestPopulation = value;
                RaisePropertyChanged("GreatestPopulation");
            }
        }

        public int SmallestPopulation
        {
            get { return model.SmallestPopulation; }
            set
            {
                model.SmallestPopulation = value;
                RaisePropertyChanged("SmallestPopulation");
            }
        }

        public int OldestCell
        {
            get { return model.OldestCell; }
            set
            {
                model.OldestCell = value;
                RaisePropertyChanged("OldestCell");
            }
        }

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