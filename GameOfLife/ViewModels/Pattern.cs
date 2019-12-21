using GameOfLife.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.ViewModels
{
    class Pattern : INotifyPropertyChanged
    {
        private ObservableCollection<Models.Pattern> patterns;
        private Models.Pattern selectedPattern;

        public Pattern()
        {
            patterns = new ObservableCollection<Models.Pattern>(PatternCollection.All);
            selectedPattern = PatternCollection.Cell;
        }

        public ObservableCollection<Models.Pattern> Patterns
        {
            get { return patterns; }
        }

        public Models.Pattern SelectedPattern
        {
            get { return selectedPattern; }
            set
            {
                selectedPattern = value;
                RaisePropertyChanged("SelectedPattern");
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
