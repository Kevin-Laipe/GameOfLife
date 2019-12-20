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
        private ViewModels.Statistics viewModel;

        public Statistics()
        {
            Init();
        }

        public void SetViewModel(ViewModels.Statistics viewModel)
        {
            this.viewModel = viewModel;
        }

        private void Init()
        {
            StackPanel panel = new StackPanel();

            CreateLabel(panel, "Iterations", "Iterations");
            CreateLabel(panel, "Population", "Population");
            CreateLabel(panel, "Greatest Population", "GreatestPopulation");
            CreateLabel(panel, "Smallest Population", "SmallestPopulation");
            CreateLabel(panel, "Oldest Cell", "OldestCell");

            this.AddChild(panel);
        }

        private void CreateLabel(StackPanel panel, string labelName, string propertyName)
        {
            Label label = new Label();
            label.Content = labelName + " : {Binding " + propertyName + "}";

            panel.Children.Add(label);
        }
    }
}
