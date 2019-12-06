using System;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameOfLife.Views
{
    class Cell : Shape
    {
        private Models.Cell model;

        public Cell(Models.Cell model)
        {
            RegisterEvents();

            this.model = model;
        }

        private void RegisterEvents()
        {

        }

        protected override Geometry DefiningGeometry => throw new NotImplementedException();
    }
}
