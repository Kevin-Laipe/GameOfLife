using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GameOfLife.Views
{
    class NumberPicker : TextBox
    {
        /*===============================*\
        |*           Attributs           *|
        \*===============================*/
        int value;
        int minValue;
        int maxValue;

        /*===============================*\
        |*         Constructeurs         *|
        \*===============================*/
        public NumberPicker()
        {
            RegisterEvents();

            value = 0;
            minValue = 0;
            maxValue = 100;

            Text = Convert.ToString(value);
        }

        /*===============================*\
        |*       Méthodes publiques      *|
        \*===============================*/
        public void SetValue(string newValue)
        {
            try
            {
                SetValue(Convert.ToInt32(this.Text));
            }
            catch
            {
                this.Text = Convert.ToString(value);
            }
        }

        public void SetValue(int newValue)
        {
            if (newValue < minValue)
                newValue = minValue;
            if (newValue > maxValue)
                newValue = maxValue;

            value = newValue;
            Text = Convert.ToString(value);
        }

        /*===============================*\
        |*       Méthodes privées        *|
        \*===============================*/

        private void RegisterEvents()
        {
            this.LostFocus += new RoutedEventHandler(OnLostFocus);
            this.GotFocus += new RoutedEventHandler(OnGotFocus);
        }

        /*===============================*\
        |*           Accesseurs          *|
        \*===============================*/

        /// <summary>
        /// Valeur du number picker
        /// </summary>
        public string Value
        {
            get { return Convert.ToString(value); }
            set { SetValue(value); }
        }

        public string Minimum
        {
            get { return Convert.ToString(minValue); }
            set { minValue = Convert.ToInt32(value); }
        }

        public string Maximum
        {
            get { return Convert.ToString(maxValue); }
            set { maxValue = Convert.ToInt32(value); }
        }

        /*===============================*\
        |*             Events            *|
        \*===============================*/

        private void OnGotFocus(object sender, RoutedEventArgs args)
        {
            this.SelectAll();
        }

        private void OnLostFocus(object sender, RoutedEventArgs args)
        {
            SetValue(Text);
        }
    }
}
