using GameOfLife.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GameOfLife.Collections
{
    class PatternCollection
    {
        private static Pattern cell;
        private static Pattern glider;
        private static Pattern lightweightSpaceship;

        private static Pattern CreateCell()
        {
            Point[] cells = { new Point(0, 0) };
            ImageSource image = new BitmapImage(new Uri("pack://application:,,,/images/cellule.PNG"));
            return new Pattern("Cellule", image, cells);
        }

        private static Pattern CreateGlider()
        {
            Point[] cells = { new Point(1, 0), new Point(2, 1), new Point(0, 2), new Point(1, 2), new Point(2, 2) };
            ImageSource image = new BitmapImage(new Uri("pack://application:,,,/images/glider.PNG"));
            return new Pattern("Glider", image, cells);
        }

        private static Pattern CreateSpaceShip()
        {
            Point[] cells = { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(3, 0),
                              new Point(0, 1), new Point(4, 1),
                              new Point(0, 2),
                              new Point(1, 3), new Point(4, 3)};
            ImageSource image = new BitmapImage(new Uri("pack://application:,,,/images/lwSpaceship.PNG"));
            return new Pattern("Lightweight Spaceship", image, cells);
        }

        public static Pattern Cell
        {
            get
            {
                if (cell == null)
                    cell = CreateCell();
                return cell;
            }
        }

        public static Pattern Glider
        {
            get
            {
                if (glider == null)
                    glider = CreateGlider();
                return glider;
            }
        }

        public static Pattern LightweightSpaceship
        {
            get
            {
                if (lightweightSpaceship == null)
                    lightweightSpaceship = CreateSpaceShip();
                return lightweightSpaceship;
            }
        }

        public static ICollection<Pattern> All
        {
            get
            {
                List<Pattern> collection = new List<Pattern>();
                collection.Add(Cell);
                collection.Add(Glider);
                collection.Add(LightweightSpaceship);
                return collection;
            }
        }
    }
}
