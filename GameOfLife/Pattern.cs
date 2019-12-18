using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GameOfLife
{
    class Pattern
    {
        public string Name { get; set; }
        public ImageSource Image { get; set; }
        public int[,] Cells { get; set; }
    }

    class PatternViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Pattern> Patterns { get; } = new ObservableCollection<Pattern>();

        private Pattern selectedPattern;
        public Pattern SelectedPattern
        {
            get { return selectedPattern; }
            set
            {
                selectedPattern = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedPattern)));
            }
        }
    }
}
