using GameOfLife.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            npWidth.SetValue(10);
            npHeight.SetValue(10);

            SetGrid(new Views.Grid(new Models.Grid(10, 10)));

            DisplayStatistics();
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
            DisplayStatistics();
        }

        private void RandomizeButton_Click(object sender, RoutedEventArgs e)
        {
            view.Model.Randomize();
            view.Refresh();
            DisplayStatistics();
        }

        private void GridPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            view.ChangeSize(e.NewSize.Width, e.NewSize.Height);
        }

        private void SpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(timer != null)
            {
                double newSpeed = e.NewValue;
                timer.Interval = TimeSpan.FromSeconds(newSpeed);
                speedLabel.Content = Math.Round(newSpeed, 2) + " secondes";
            }
        }

        private void SizeButton_Click(object sender, RoutedEventArgs args)
        {
            Models.Grid model = view.Model;
            int width = Convert.ToInt32(npWidth.Value);
            int height = Convert.ToInt32(npHeight.Value);

            if (model.Width != width || model.Height != height)
            {
                SetGrid(view.Resize(width, height));
                view.ChangeSize(GridPanel.ActualWidth, GridPanel.ActualHeight);
            }
            DisplayStatistics();
        }

        private void Timer_Tick(Object sender, EventArgs args)
        {
            GameOfLifeAlgorithm.Update(view.Model);
            view.Refresh();
            DisplayStatistics();
        }

        private void SetGrid(Views.Grid newGrid)
        {
            view = newGrid;
            GridPanel.Children.Clear();   
            GridPanel.Children.Add(newGrid);
        }

        private void DisplayStatistics()
        {
            Statistics statistics = view.Model.Statistics;

            lblIterations.Content = "Itérations : " + statistics.iterations;
            lblPopulation.Content = "Population actuelle : " + statistics.population;
            lblMaxPopulation.Content = "Population max : " + statistics.greatestPopulation;
            lblMinPopulation.Content = "Population min : " + statistics.smallestPopulation;
            lblOldest.Content = "Age maximal : " + statistics.oldestCell;
        }
    }
}
