using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace GameOfLife.Views
{
    class Grid : System.Windows.Controls.Grid
    {
        private Models.Grid model;

        public Grid(Models.Grid model)
        {
            this.model = model;
            this.Height = 100;
            this.Width = 100;

            CreateCells();
        }

        private void CreateCells()
        {
            for(int x = 0; x < model.Width; x++)
            {
                this.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for(int y = 0; y < model.Height; y++)
            {
                this.RowDefinitions.Add(new RowDefinition());
            }

            for(int y = 0; y < model.Height; y++)
            {
                for(int x = 0; x < model.Width; x++)
                {
                    Rectangle newCell = new Rectangle();
                    newCell.Width = 10;
                    newCell.Height = 10;
                    if((x + y) % 2 == 0)
                    {
                        newCell.Fill = Brushes.Red;
                    }
                    else
                    {
                        newCell.Fill = Brushes.Blue;
                    }
                    
                    this.Children.Add(newCell);
                    Grid.SetRow(newCell, x);
                    Grid.SetColumn(newCell, y);
                }
            }
        }
    }
}
