using GameOfLife.Models;
using System;
using System.Windows;
using System.Windows.Threading;

namespace GameOfLife
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Attributs
        DispatcherTimer timer;
        Views.Grid view;

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(1);

            numberWidth.SetValue(10);
            numberHeight.SetValue(10);

            view = grid;
        }

        /// <summary>
        /// Appelé lorsque le bouton start est clické
        /// </summary>
        /// <param name="sender">objet appelant cet méthode</param>
        /// <param name="args">arguments lié à l'événement</param>
        private void buttonStart_Clicked(object sender, RoutedEventArgs args)
        {
            timer.Start();
        }

        /// <summary>
        /// Appelé lorsque le bouton stop est clické
        /// </summary>
        /// <param name="sender">objet appelant cet méthode</param>
        /// <param name="args">arguments lié à l'événement</param>
        private void buttonStop_Clicked(object sender, RoutedEventArgs args)
        {
            timer.Stop();
        }

        /// <summary>
        /// Appelé lorsque le bouton reset est clické
        /// </summary>
        /// <param name="sender">objet appelant cet méthode</param>
        /// <param name="args">arguments lié à l'événement</param>
        private void buttonReset_Clicked(object sender, RoutedEventArgs e)
        {
            view.ViewModel.Clear();
        }

        /// <summary>
        /// Appelé lorsque le bouton randomize est clické
        /// </summary>
        /// <param name="sender">objet appelant cet méthode</param>
        /// <param name="args">arguments lié à l'événement</param>
        private void buttonRandomize_Click(object sender, RoutedEventArgs e)
        {
            view.ViewModel.Randomize();
        }

        /// <summary>
        /// Appelé lorsque le panel contenant la grille est resize
        /// </summary>
        /// <param name="sender">objet appelant cet méthode</param>
        /// <param name="e">arguments lié à l'événement</param>
        private void panelGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            view.ChangeSize(e.NewSize.Width, e.NewSize.Height);
        }

        /// <summary>
        /// Appelé lorsque la valeur de slider change
        /// </summary>
        /// <param name="sender">objet appelant cet méthode</param>
        /// <param name="e">arguments lié à l'événement</param>
        private void sliderSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(timer != null)
            {
                double newSpeed = e.NewValue;
                timer.Interval = TimeSpan.FromSeconds(newSpeed);
                labelSpeed.Content = Math.Round(newSpeed, 2) + " secondes";
            }
        }

        /// <summary>
        /// Appelé lorsque le bouton de redimensionnement est clické
        /// </summary>
        /// <param name="sender">objet appelant cet méthode</param>
        /// <param name="args">arguments lié à l'événement</param>
        private void buttonSize_Click(object sender, RoutedEventArgs args)
        {
            ViewModels.Grid viewModel = view.ViewModel;
            int width = Convert.ToInt32(numberWidth.Value);
            int height = Convert.ToInt32(numberHeight.Value);

            if (viewModel.Width != width || viewModel.Height != height)
            {
                SetGrid(view.Resize(width, height));
                view.ChangeSize(panelGrid.ActualWidth, panelGrid.ActualHeight);
            }
        }

        /// <summary>
        /// Appelé lorsque le timer effectue un tick
        /// </summary>
        /// <param name="sender">objet appelant cet méthode</param>
        /// <param name="args">arguments lié à l'événement</param>
        private void Timer_Tick(Object sender, EventArgs args)
        {
            GameOfLifeAlgorithm.Update(view.ViewModel);
        }

        /// <summary>
        /// Change de grille affichée sur l'interface
        /// </summary>
        /// <param name="newGrid">La nouvelle grille</param>
        private void SetGrid(Views.Grid newGrid)
        {
            view = newGrid;
            panelGrid.Children.Clear();   
            panelGrid.Children.Add(newGrid);
        }
    }
}
