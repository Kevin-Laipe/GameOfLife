using GameOfLife.Enums;
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
        private ViewModels.Cell viewModel;
        
        /// <summary>
        /// Constructeur de la classe Cell (View)
        /// </summary>
        /// <param name="model">Modèle de la cellule</param>
        public Cell(ViewModels.Cell viewModel) : base()
        {
            this.viewModel = viewModel;

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
            viewModel.State = (CellState)((int)(viewModel.State + 1) % 2);
            this.Background = viewModel.GetColor();
        }

        public ViewModels.Cell ViewModel
        {
            get { return viewModel; }
        }
    }
}
