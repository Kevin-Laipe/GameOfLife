using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameOfLife.Views
{
    class Statistics : GroupBox
    {
        //Attributs
        private static string HEADER_TEXT = "Statistiques";
        private ViewModels.Statistics viewModel;
        private StackPanel panel;

        public Statistics()
        {
            viewModel = new ViewModels.Statistics();

            Init();
        }

        private void Init()
        {
            this.Header = HEADER_TEXT;

            panel = new StackPanel();
            panel.Orientation = Orientation.Vertical;
            this.AddChild(panel);
        }
    }
}
