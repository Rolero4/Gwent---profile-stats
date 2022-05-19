using System.ComponentModel;

namespace Players
{
    /// <summary>
    /// Bazowa klasa dla modelu widoku implementująca interfejs INotifyPropertyChanged
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Zdarzenie uruchamiane, gdy dowolna właściwość zmienia swoją wartość
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                 PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
