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
    /// <summary>
    /// Vue-Modèle d'un pattern de Game Of Life
    /// </summary>
    class Pattern : INotifyPropertyChanged
    {
        /*===============================*\
        |*           Attributs           *|
        \*===============================*/
        private ObservableCollection<Models.Pattern> patterns;
        private Models.Pattern selectedPattern;

        /*===============================*\
        |*           Accesseurs          *|
        \*===============================*/

        /// <summary>
        /// Collection de pattern
        /// </summary>
        public ObservableCollection<Models.Pattern> Patterns
        {
            get { return patterns; }
        }

        /// <summary>
        /// Pattern séléctioné
        /// </summary>
        public Models.Pattern SelectedPattern
        {
            get { return selectedPattern; }
            set
            {
                selectedPattern = value;
                RaisePropertyChanged("SelectedPattern");
            }
        }

        /*===============================*\
        |*             Events            *|
        \*===============================*/

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Lève l'event PropertyChanged d'une propriété
        /// </summary>
        /// <param name="propertyName">Nom de la propriété</param>
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
