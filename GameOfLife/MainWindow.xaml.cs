using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameOfLife
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        Views.Grid view;
        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(1);

            Models.Grid model = new Models.Grid(10, 10);
            view = new Views.Grid(model);
            GridPanel.Children.Add(view);
        }

        private void StartButton_Clicked(object sender, RoutedEventArgs args)
        {
            timer.Start();
        }

        private void StopButton_Clicked(object sender, RoutedEventArgs args)
        {
            timer.Stop();
        }

        private void ResetButton_Clicked(object sender, RoutedEventArgs e)
        {
            view.Model.Clear();
            view.Refresh();
        }

        private void RandomizeButton_Clicked(object sender, RoutedEventArgs e)
        {
            view.Model.Randomize();
            view.Refresh();
        }

        private void GridPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double size = GridPanel.ActualHeight;
            if (size > GridPanel.ActualWidth)
            {
                size = GridPanel.ActualWidth;
            }

            view.Width = size;
            view.Height = size;
        }

        private void SpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                timer.Interval = TimeSpan.FromSeconds(1 / e.NewValue);
            }
            catch(NullReferenceException ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void Timer_Tick(Object sender, EventArgs args)
        {
            GameOfLifeAlgorithm.Update(view.Model);
            view.Refresh();
        }
    }
}
