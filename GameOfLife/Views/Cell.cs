﻿using GameOfLife.Enums;
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
    class Cell : Button
    {
        /*===============================*\
        |*           Attributs           *|
        \*===============================*/
        private ViewModels.Cell viewModel;
        
        /*===============================*\
        |*        Constructeurs          *|
        \*===============================*/

        public Cell(ViewModels.Cell viewModel) : base()
        {
            this.viewModel = viewModel;

            Init();
            RegisterEvents();
        }

        /*===============================*\
        |*        Méthodes Privées       *|
        \*===============================*/

        private void Init()
        {
            this.Background = Brushes.Transparent;
        }

        private void RegisterEvents()
        {
            this.MouseRightButtonDown += new MouseButtonEventHandler(OnRightClick);
            viewModel.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);
        }

        /*===============================*\
        |*          Accesseurs           *|
        \*===============================*/

        public ViewModels.Cell ViewModel
        {
            get { return viewModel; }
        }

        /*===============================*\
        |*             Events            *|
        \*===============================*/

        private void OnRightClick(Object sender, MouseButtonEventArgs args)
        {
            this.ViewModel.State = CellState.Dead;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if(args.PropertyName == "State")
            {
                this.Background = viewModel.GetColor();
            }
        }
    }
}
