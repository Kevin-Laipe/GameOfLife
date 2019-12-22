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
    /// <summary>
    /// Vue-Modèle d'une cellule de Game Of Life
    /// </summary>
    class Cell : INotifyPropertyChanged
    {
        /*===============================*\
        |*           Attributs           *|
        \*===============================*/
        Models.Cell model;
        private CellState nextState;

        /*===============================*\
        |*        Constructeurs          *|
        \*===============================*/

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Cell() : this(new Models.Cell()) { }

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="model">Modèle de la cellule</param>
        public Cell(Models.Cell model)
        {
            this.model = model;
        }

        /*===============================*\
        |*      Méthodes publiques       *|
        \*===============================*/

        /// <summary>
        /// Retourne la couleur de la cellule en fonction de l'état
        /// </summary>
        /// <returns>Couleur de la cellule</returns>
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

        /// <summary>
        /// Prépare (enregistre) le prochain état
        /// </summary>
        /// <param name="nextState">Prochain état</param>
        public void Prepare(CellState nextState)
        {
            this.nextState = nextState;   
        }

        /// <summary>
        /// Applique le prochain état
        /// </summary>
        public void Apply()
        {
            this.State = nextState;
            this.Age = (this.State == CellState.Alive) ? this.Age + 1 : 0;
        }

        /*===============================*\
        |*           Accesseurs          *|
        \*===============================*/

        /// <summary>
        /// Etat de la cellule
        /// </summary>
        public CellState State
        {
            get { return model.State; }
            set
            {
                if(value != model.State)
                {
                    model.State = value;
                    RaisePropertyChanged("State");
                }
            }
        }

        /// <summary>
        /// Age de la cellule
        /// </summary>
        public int Age
        {
            get { return model.Age; }
            private set
            {
                if(this.Age != value)
                {
                    this.model.Age = value;
                    RaisePropertyChanged("Age");
                }
            }
        }

        /// <summary>
        /// Position X de la cellule dans la grille
        /// </summary>
        public int X
        {
            get { return model.X; }
            set { model.X = value; }
        }

        /// <summary>
        /// Position Y de la cellule dans la grille
        /// </summary>
        public int Y
        {
            get { return model.Y; }
            set { model.Y = value; }
        }

        /*===============================*\
        |*            Events             *|
        \*===============================*/

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Lève l'event PropertyChanged d'une proprité
        /// </summary>
        /// <param name="propertyName">Nom de la propriété</param>
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
