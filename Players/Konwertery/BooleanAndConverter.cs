using System;
using System.Windows.Data;

namespace Players.BooleanAndConverter
{
    /// <summary>
    /// Konwerter zamieniający dwie wartości typu bool w jedną (AND)
    /// Potrzebny do wiązania danych
    /// </summary>
    public class BooleanAndConverter : IMultiValueConverter
    {
        /// <summary>
        /// Konwersja dwóch wartości typu bool w jedną (AND)
        /// </summary>
        /// <param name="values">Wartości typu bool</param>
        /// <param name="targetType">Wartość typu bool</param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            foreach (object value in values)
            {
                if ((value is bool) && (bool)value == false)
                {
                    return false;
                }
            }
            return true;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("BooleanAndConverter is a OneWay converter.");
        }
    }
}
