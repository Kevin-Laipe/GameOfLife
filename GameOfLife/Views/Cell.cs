using GameOfLife.Enums;
using GameOfLife.Models;
using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameOfLife.Views
{
    /// <summary>
    /// Vue d'une cellule de Game Of Life
    /// </summary>
    class Cell : Button
    {
        /*===============================*\
        |*           Attributs           *|
        \*===============================*/
        private ViewModels.Cell viewModel;
        
        /*===============================*\
        |*        Constructeurs          *|
        \*===============================*/

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="viewModel">Vue-Modèle de la cellule</param>
        public Cell(ViewModels.Cell viewModel) : base()
        {
            this.viewModel = viewModel;

            Init();
            RegisterEvents();
        }

        /*===============================*\
        |*        Méthodes Privées       *|
        \*===============================*/

        /// <summary>
        /// Initialise la cellule
        /// </summary>
        private void Init()
        {
            this.Background = Brushes.Transparent;
        }

        /// <summary>
        /// Enregistre les events liés à la cellule
        /// </summary>
        private void RegisterEvents()
        {
            this.MouseRightButtonDown += new MouseButtonEventHandler(OnRightClick);
            viewModel.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);
        }

        /*===============================*\
        |*          Accesseurs           *|
        \*===============================*/

        /// <summary>
        /// Vue-Modèle de la cellule
        /// </summary>
        public ViewModels.Cell ViewModel
        {
            get { return viewModel; }
        }

        /*===============================*\
        |*             Events            *|
        \*===============================*/

        /// <summary>
        /// Méthode appelé lorsque un clique droit est effectué sur cette cellule
        /// </summary>
        /// <param name="sender">Envoyeur de l'event</param>
        /// <param name="args">Arguments de l'event</param>
        private void OnRightClick(Object sender, MouseButtonEventArgs args)
        {
            this.ViewModel.State = CellState.Dead;
        }

        /// <summary>
        /// Méthode appelé lorsque une propriété de la cellule est modifiée
        /// </summary>
        /// <param name="sender">Envoyeur de l'event</param>
        /// <param name="args">Arguments de l'event</param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if(args.PropertyName == "State")
            {
                this.Background = viewModel.GetColor();
            }
        }
    }
}
