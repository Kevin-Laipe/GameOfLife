using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GameOfLife.Models
{
    class Pattern
    {
        private string name;
        private ImageSource image;
        private Point[] cells;

        public Pattern(string name, ImageSource image, Point[] cells)
        {
            this.name = name;
            this.image = image;
            this.cells = cells;
        }

        public string Name
        {
            get { return name; }
        }

        public ImageSource Image
        {
            get { return image; }
        }

        public Point[] Cells
        {
            get { return cells; }
        }
    }
}
