using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GameOfLife.Models
{
    /// <summary>
    /// Modèle d'un pattern (ensemble de cellules) de Game Of Life
    /// </summary>
    class Pattern
    {
        /*===============================*\
        |*           Attributs           *|
        \*===============================*/
        private string name;
        private ImageSource image;
        private Point[] cells;

        /*===============================*\
        |*         Constructeurs         *|
        \*===============================*/

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="name">Nom du pattern</param>
        /// <param name="image">Image du pattern</param>
        /// <param name="cells">Coordonées relative des cellules du pattern</param>
        public Pattern(string name, ImageSource image, Point[] cells)
        {
            this.name = name;
            this.image = image;
            this.cells = cells;
        }

        /*===============================*\
        |*           Accesseurs          *|
        \*===============================*/

        /// <summary>
        /// Nom du pattern
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Image du pattern
        /// </summary>
        public ImageSource Image
        {
            get { return image; }
        }

        /// <summary>
        /// Coordonées relative des cellules du pattern
        /// </summary>
        public Point[] Cells
        {
            get { return cells; }
        }
    }
}
