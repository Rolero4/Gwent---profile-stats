using System.Windows;

namespace Players
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Kontekstem danych dla okna będzie obiekt klasy ViewModel
            this.DataContext = new ViewModel();




        }
    }
}
