using GameOfLife.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GameOfLife.Collections
{
    /// <summary>
    /// Classe statique contenant tout les patterns
    /// Cette classe utilise la méthode du singleton pour l'instantiation des patterns
    /// </summary>
    class PatternCollection
    {
        /*===============================*\
        |*           Attributs           *|
        \*===============================*/
        private static Pattern cell;
        private static Pattern glider;
        private static Pattern lightweightSpaceship;

        /*===============================*\
        |*        Méthodes Privées       *|
        \*===============================*/

        /// <summary>
        /// Créé le pattern de la cellule
        /// </summary>
        /// <returns>Pattern de la cellule</returns>
        private static Pattern CreateCell()
        {
            Point[] cells = { new Point(0, 0) };
            ImageSource image = new BitmapImage(new Uri("pack://application:,,,/Images/cellule.PNG"));
            return new Pattern("Cellule", image, cells);
        }

        /// <summary>
        /// Créé le pattern du Glider
        /// </summary>
        /// <returns>Pattern du Glider</returns>
        private static Pattern CreateGlider()
        {
            Point[] cells = { new Point(1, 0), new Point(2, 1), new Point(0, 2), new Point(1, 2), new Point(2, 2) };
            ImageSource image = new BitmapImage(new Uri("pack://application:,,,/Images/glider.PNG"));
            return new Pattern("Glider", image, cells);
        }

        /// <summary>
        /// Créé le pattern du Lightweight Spaceship
        /// </summary>
        /// <returns>Pattern du Lightweight Spaceship</returns>
        private static Pattern CreateSpaceShip()
        {
            Point[] cells = { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(3, 0),
                              new Point(0, 1), new Point(4, 1),
                              new Point(0, 2),
                              new Point(1, 3), new Point(4, 3)};
            ImageSource image = new BitmapImage(new Uri("pack://application:,,,/Images/lwSpaceship.PNG"));
            return new Pattern("Lightweight Spaceship", image, cells);
        }

        /*===============================*\
        |*           Accesseurs          *|
        \*===============================*/

        /// <summary>
        /// Pattern de la cellule
        /// </summary>
        public static Pattern Cell
        {
            get
            {
                if (cell == null)
                    cell = CreateCell();
                return cell;
            }
        }

        /// <summary>
        /// Pattern du Glider
        /// </summary>
        public static Pattern Glider
        {
            get
            {
                if (glider == null)
                    glider = CreateGlider();
                return glider;
            }
        }

        /// <summary>
        /// Pattern du Lightweight Spaceship
        /// </summary>
        public static Pattern LightweightSpaceship
        {
            get
            {
                if (lightweightSpaceship == null)
                    lightweightSpaceship = CreateSpaceShip();
                return lightweightSpaceship;
            }
        }

        /// <summary>
        /// Collection contenant tout les patterns
        /// </summary>
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
