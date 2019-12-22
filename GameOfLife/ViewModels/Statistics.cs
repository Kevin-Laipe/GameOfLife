using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameOfLife.ViewModels
{
    /// <summary>
    /// Vue-Modèle des statistiques de Game Of Life
    /// </summary>
    class Statistics : INotifyPropertyChanged
    {
        /*===============================*\
        |*           Attributs           *|
        \*===============================*/
        private Models.Statistics model;

        /*===============================*\
        |*         Constructeurs         *|
        \*===============================*/

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Statistics()
        {
            this.model = new Models.Statistics();
        }

        /*===============================*\
        |*       Méthodes Publiques      *|
        \*===============================*/

        /// <summary>
        /// Met toutes les statistiques à zéro
        /// </summary>
        public void Reset()
        {
            Iterations = 0;
            Population = 0;
            GreatestPopulation = 0;
            SmallestPopulation = 0;
            OldestCell = 0;
        }

        /*===============================*\
        |*           Accesseurs          *|
        \*===============================*/

        /// <summary>
        /// Nombre d'itérations
        /// </summary>
        public int Iterations
        {
            get { return model.Iterations; }
            set
            {
                model.Iterations = value;
                RaisePropertyChanged("Iterations");
            }
        }

        /// <summary>
        /// Population actuelle
        /// </summary>
        public int Population
        {
            get { return model.Population; }
            set
            {
                model.Population = value;
                RaisePropertyChanged("Population");
            }
        }

        /// <summary>
        /// Population maximale
        /// </summary>
        public int GreatestPopulation
        {
            get { return model.GreatestPopulation; }
            set
            {
                model.GreatestPopulation = value;
                RaisePropertyChanged("GreatestPopulation");
            }
        }

        /// <summary>
        /// Population minimale
        /// </summary>
        public int SmallestPopulation
        {
            get { return model.SmallestPopulation; }
            set
            {
                model.SmallestPopulation = value;
                RaisePropertyChanged("SmallestPopulation");
            }
        }

        /// <summary>
        /// Age de la plus vielle cellule
        /// </summary>
        public int OldestCell
        {
            get { return model.OldestCell; }
            set
            {
                model.OldestCell = value;
                RaisePropertyChanged("OldestCell");
            }
        }

        /*===============================*\
        |*            Events             *|
        \*===============================*/

        public event PropertyChangedEventHandler PropertyChanged;
        
        /// <summary>
        /// Lève l'event PropertyChanged d'une propriété
        /// </summary>
        /// <param name="propertyName">Nom de la propiété</param>
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
