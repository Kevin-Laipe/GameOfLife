using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GameOfLife.Views
{
    class NumberPicker : TextBox
    {
        int value;
        int minValue;
        int maxValue;

        public NumberPicker()
        {
            RegisterEvents();

            value = 0;
            minValue = 0;
            maxValue = 100;

            Text = Convert.ToString(value);
        }

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

        private void RegisterEvents()
        {
            this.LostFocus += new RoutedEventHandler(OnLostFocus);
            this.GotFocus += new RoutedEventHandler(OnGotFocus);
        }

        private void OnGotFocus(object sender, RoutedEventArgs args)
        {
            this.SelectAll();
        }

        private void OnLostFocus(object sender, RoutedEventArgs args)
        {
            SetValue(Text);
        }

        /// <summary>
        /// Valeur du number picker
        /// </summary>
        public string Value
        {
            get { return Convert.ToString(value); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Valeur minimal du number picker
        /// </summary>
        public string Minimum
        {
            get { return Convert.ToString(minValue); }
            set { minValue = Convert.ToInt32(value); }
        }

        /// <summary>
        /// Valeur maximal du number picker
        /// </summary>
        public string Maximum
        {
            get { return Convert.ToString(maxValue); }
            set { maxValue = Convert.ToInt32(value); }
        }
    }
}
