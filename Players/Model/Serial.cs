using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Players.Model
{
    /// <summary>
    /// Pomocnicza klasa z metodami zapisu/odczytu stanu aplikacji
    /// </summary>
    public static class Serial
    {
        private const string V = @"../../../Resources/Gwenters.xml";

        // Ścieżka do pliku xml
        private static readonly string pathToXMLFile = V;

        #region Serialization

        /// <summary>
        /// Statyczna metoda zapisująca stan aplikacji do pliku xml.
        /// </summary>
        /// <param name="collectionOfPlayers">Kolekcja piłkarzy do zapisania</param>

        public static void Save(ObservableCollection<PlayerViewModel> collectionOfPlayers)
        {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<PlayerViewModel>));
            XmlSerializer xs = xmlSerializer;
            using StreamWriter wr = new StreamWriter(pathToXMLFile);
            xs.Serialize(wr, collectionOfPlayers);

        }
        #endregion

        #region deserialization

        /// <summary>
        /// Statyczna metoda czytająca piłkarzy z pliku xml,
        /// zwracająca kolekcję obiektów PlayerViewModel
        /// </summary>

        public static ObservableCollection<PlayerViewModel>? Load()
        {
            XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<PlayerViewModel>));
            ObservableCollection<PlayerViewModel>? players;
            using (XmlReader reader = XmlReader.Create(pathToXMLFile))
            {
                players = (ObservableCollection<PlayerViewModel>)ser.Deserialize(reader);
            }
            return players;
        }
        #endregion
    }
}
