using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GameOfLife.Views
{
    /// <summary>
    /// Element permettant la saisie d'un nombre entier
    /// </summary>
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

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
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

        /// <summary>
        /// Modifie la valeur actuelle
        /// </summary>
        /// <param name="newValue">Nouvelle valeur</param>
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

        /// <summary>
        /// Modifie la valeur actuelle
        /// </summary>
        /// <param name="newValue">Nouvelle valeur</param>
        public void SetValue(int newValue)
        {
            if (newValue < minValue)
                newValue = minValue;
            if (newValue > maxValue)
                newValue = maxValue;

            value = newValue;
            Text = Convert.ToString(value);
        }

        /// <summary>
        /// Retourne la valeur actuelle
        /// </summary>
        /// <returns></returns>
        public int GetValue()
        {
            return value;
        }

        /*===============================*\
        |*       Méthodes privées        *|
        \*===============================*/

        /// <summary>
        /// Enregistre les événements de cette élément
        /// </summary>
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

        /// <summary>
        /// Valeur minimal possible
        /// </summary>
        public string Minimum
        {
            get { return Convert.ToString(minValue); }
            set { minValue = Convert.ToInt32(value); }
        }

        /// <summary>
        /// Valeur maximale possible
        /// </summary>
        public string Maximum
        {
            get { return Convert.ToString(maxValue); }
            set { maxValue = Convert.ToInt32(value); }
        }

        /*===============================*\
        |*             Events            *|
        \*===============================*/

        /// <summary>
        /// Méthode appelée lorsque l'élément a la focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnGotFocus(object sender, RoutedEventArgs args)
        {
            this.SelectAll();
        }

        /// <summary>
        /// Méthode appelée lorsque l'élément perd le focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnLostFocus(object sender, RoutedEventArgs args)
        {
            SetValue(Text);
        }
    }
}
