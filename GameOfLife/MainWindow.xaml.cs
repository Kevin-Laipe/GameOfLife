using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace GameOfLife
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Views.Grid view;
        public MainWindow()
        {
            InitializeComponent();

            Models.Grid model = new Models.Grid(10, 10);
            view = new Views.Grid(model);
            GridPanel.Children.Add(view);
        }

        private void GridPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double size = GridPanel.ActualHeight;
            if(size > GridPanel.ActualWidth)
            {
                size = GridPanel.ActualWidth;
            }

            view.Width = size;
            view.Height = size;

        }
    }
}
