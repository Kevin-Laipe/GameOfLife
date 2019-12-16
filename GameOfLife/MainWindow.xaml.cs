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

            Models.Grid model = new Models.Grid(Convert.ToInt32(xTextBox.Text), Convert.ToInt32(yTextBox.Text));
            view = new Views.Grid(model);
            GridPanel.Children.Add(view);

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

        private void RandomizeButton_Clicked(object sender, RoutedEventArgs e)
        {
            view.Model.Randomize();
            view.Refresh();
            DisplayStatistics();
        }

        private void GridPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double size = GridPanel.ActualHeight;
            if (size > GridPanel.ActualWidth)
                size = GridPanel.ActualWidth;

            view.Width = size;
            view.Height = size;
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

        /// <summary>
        /// On ne prend que des chiffres dans les text boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad0:
                case Key.NumPad1:
                case Key.NumPad2:
                case Key.NumPad3:
                case Key.NumPad4:
                case Key.NumPad5:
                case Key.NumPad6:
                case Key.NumPad7:
                case Key.NumPad8:
                case Key.NumPad9:
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                case Key.Back:
                    e.Handled = false;
                    break;
                default:
                    e.Handled = true;
                    break;
            }

        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (IsValidInt(e.Text))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private bool IsValidInt(string s)
        {
            Regex r = new Regex(@"\d");
            return r.IsMatch(s);
        }

        private void Timer_Tick(Object sender, EventArgs args)
        {
            GameOfLifeAlgorithm.Update(view.Model);
            view.Refresh();
            DisplayStatistics();

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
