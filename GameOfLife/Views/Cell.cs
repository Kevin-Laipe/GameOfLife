using GameOfLife.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameOfLife.Views
{
    class Cell : Button
    {
        //Attributs
        private Models.Cell model;
        private Statistics statistics;
        
        /// <summary>
        /// Constructeur de la classe Cell (View)
        /// </summary>
        /// <param name="model">Modèle de la cellule</param>
        public Cell(Models.Cell model, Statistics statistics) : base()
        {
            this.model = model;
            this.statistics = statistics;

            Init();
            RegisterEvents();
        }

        /// <summary>
        /// Initialisation de l'objet
        /// </summary>
        private void Init()
        {
            this.Background = Brushes.Transparent;
        }

        /// <summary>
        /// Ajoute tous les événements de cet objet
        /// </summary>
        private void RegisterEvents()
        {
            this.Click += new RoutedEventHandler(OnMouseClick);
        }

        /// <summary>
        /// Fonction appelée lorsque la souris clique sur cet élément
        /// </summary>
        /// <param name="sender">Objet qui appelle la fonction (Dans ce cas toujours une cellule)</param>
        /// <param name="args">Arguments concernant l'évévenemnt</param>
        private void OnMouseClick(Object sender, RoutedEventArgs args)
        {
            model.State = (Models.Cell.CellState)((int)(model.State + 1) % 2);

            UpdateColor();
        }

        /// <summary>
        /// Change la couleur en fonction de l'état actuel de la cellule
        /// </summary>
        public void UpdateColor()
        {
            switch(model.State)
            {
                case Models.Cell.CellState.Alive:
                    this.Background = Brushes.Green;
                    break;

                case Models.Cell.CellState.Dead:
                default:
                    this.Background = Brushes.Transparent;
                    break;
            }
        }

        private Models.Cell Model
        {
            get { return model; }
        }
    }
}
