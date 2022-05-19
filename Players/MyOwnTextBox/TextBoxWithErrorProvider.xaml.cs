using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace Players.MyOwnTextBox
{
    /// <summary>
    /// Logika interakcji dla klasy TextBoxWithErrorProvider.xaml
    /// </summary>
    public partial class TextBoxWithErrorProvider : UserControl
    {
        #region Własności publiczne

        public static Brush BrushForAll { get; set; } = Brushes.Red;

        public Brush TextBoxBorderBrush
        {
            get
            {
                return border.BorderBrush;
            }
            set
            {
                border.BorderBrush = value;
            }
        }

        public string ToolTipText { get; set; } = "Uzupełnij dane";

        #endregion

        #region Konstruktor

        /// <summary>
        /// Konstruktor domniemany
        /// </summary>
        public TextBoxWithErrorProvider()
        {
            InitializeComponent();
            // Ustawienie koloru obramowania
            border.BorderBrush = BrushForAll;
        }

        #endregion

        #region Metoda SetError

        /// <summary>
        /// Metoda ustawiąjąca ToolTip i grubość obramowania,
        /// w przypadku gdy w TextBoxie mamy pusty ciąg znaków
        /// </summary>
        /// <param name="errorText"></param>
        public void SetError(string errorText)
        {
            textBlockToolTip.Text = errorText;


            if (textBox.Text == "")
            {
                // Brak danych
                border.BorderThickness = new Thickness(1);
                toolTip.Visibility = Visibility.Visible;
                this.IsNotEmpty = false;
            }
            else
            {
                // Zgłoszenie błędu
                border.BorderThickness = new Thickness(0);
                toolTip.Visibility = Visibility.Hidden;
                this.IsNotEmpty = true;
            }
        }

        #endregion

        #region Obsługa zdarzeń

        /// <summary>
        /// W przypadku zmiany tekstu w kotrolce,
        /// sprawdzamy czy, aby nie ma pustego ciągu znaków
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetError(ToolTipText);
        }

        /// <summary>
        /// W przypadku focusu kontrolki,
        /// sprawdzamy czy, aby nie ma pustego ciągu znaków
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SetError(ToolTipText);
        }

        #endregion

        #region Obsługa wiązania danych z właściwością Text

        /// <summary>
        /// Rejestracja właściwości TextProperty (w celu wiązania danych)
        /// </summary>
        public static readonly DependencyProperty TextProperty =
       DependencyProperty.Register(
          "Text",
          typeof(string),
          typeof(TextBoxWithErrorProvider),
          new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Publiczna właściwość Text
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion

        #region Obsługa wiązania danych z właściwością IsNotEmpty

        /// <summary>
        /// Rejestracja właściwości IsEmptyProperty (w celu wiązania danych)
        /// </summary>
        public static readonly DependencyProperty IsNotEmptyProperty =
       DependencyProperty.Register(
          "IsNotEmpty",
          typeof(bool),
          typeof(TextBoxWithErrorProvider));

        /// <summary>
        /// Publiczna właściwość IsNotEmpty
        /// </summary>
        public bool IsNotEmpty
        {
            get { return (bool)GetValue(IsNotEmptyProperty); }
            set { SetValue(IsNotEmptyProperty, value); }
        }

        #endregion
    }
}
