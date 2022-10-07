using System.Collections.ObjectModel;
using Player.Model;
using Players.WindowAddPlayer;

namespace Players
{
    public class ViewModel : BaseViewModel
    {
        #region Prywatne pola

        // Pole przechowujące stan piłkarza wyświetlanego w formularzu
        private PlayerViewModel displayedPlayer;

        // Pole przechowujące stan piłkarza wybranego z listy
        private PlayerViewModel selectedPlayer;

        // Pole przechowujące stan nowego piłkarza
        private PlayerViewModel newPlayer;

        // Lista piłkarzy
        private ObservableCollection<PlayerViewModel> listOfPlayers;

        // Polecenie zapisania stanu aplikacji
        private RelayCommand saveCommand;

        // Polecenie usunięcia piłkarza z kolekcji
        private RelayCommand deletePlayerCommand;

        // Polecenie dodania piłkarza do kolekcji
        private RelayCommand addPlayerCommand;

        //dodanie loga do kolekcji
        private RelayCommand addLogCommand;

        //usunięcie ostatniego logu
        private RelayCommand deleteLastLogCommand;

        #endregion

        #region Kostruktor

        /// <summary>
        /// Konstruktor domyślny
        /// </summary>
        public ViewModel()
        {
            // Załadowanie listy piłkarzy z pliku
            listOfPlayers = Serial.Load();

            //wyswietlony zawodnik to pusty 
            displayedPlayer = new PlayerViewModel();

            // Stworzenie nowego piłkarza
            newPlayer = new PlayerViewModel();
        }

        #endregion

        #region Własności publiczne

        /// <summary>
        /// Własność zwracająca piłkarza wyświetlanego w formularzu
        /// </summary>
        public PlayerViewModel DisplayedPlayer
        {
            get { return displayedPlayer; }
        }


        /// <summary>
        /// Własność zwracająca referencję do nowo tworzonego piłkarza
        /// </summary>
        public PlayerViewModel NewPlayer
        {
            get { return newPlayer; }
        }

        /// <summary>
        /// Własność zwracająca piłkarza zaznaczonego z ListBoxa
        /// </summary>
        public PlayerViewModel SelectedPlayer
        {
            get { return selectedPlayer; }
            set
            {
                if (value != null)
                {
                    // Kopiujemy referencję wybranego piłkarza z listy do pola selectedPlayer
                    selectedPlayer = value;

                    // Kopiujemy stan zaznaczonego piłkarza (tylko stan, bez referencji)
                    // do pola displayedPlayer
                    displayedPlayer.Name = value.Name;
                    displayedPlayer.Url = value.Url;
                    displayedPlayer.Stats = value.Stats;
                }
            }
        }

        /// <summary>
        /// Własność zwracająca listę piłkarzy
        /// </summary>
        public ObservableCollection<PlayerViewModel> ListOfPlayers
        {
            get { return listOfPlayers; }
            set { listOfPlayers = value; onPropertyChanged(nameof(ListOfPlayers)); }
        }
        #endregion 

        #region RelayCommands
        /// <summary>
        /// Właściwość publiczna udostępniająca polecenie zapisania kolekcji
        /// </summary>
        public RelayCommand Save
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new RelayCommand(argument => { Serial.Save(listOfPlayers); }, argument => true);
                return saveCommand;
            }
        }

        /// <summary>
        /// Właściwość publiczna udostępniająca polecenie usunięcia piłkarza z kolekcji
        /// </summary>
        public RelayCommand DeletePlayer
        {
            get
            {
                if (deletePlayerCommand == null)
                    deletePlayerCommand = new RelayCommand(argument => { listOfPlayers.Remove(selectedPlayer); displayedPlayer.Stats = null; displayedPlayer.Name = null; }, argument => true);
                return deletePlayerCommand;
            }
        }

        /// <summary>
        /// Własność publiczna udostępniąjąca polecenie dodania piłkarza z kolekcji
        /// </summary>
        public RelayCommand AddPlayer
        {
            get
            {
                if (addPlayerCommand == null)
                    addPlayerCommand = new RelayCommand(argument =>
                    {
                        // Tworzymy nowe okno z formularzem dodania piłkarza
                        AddPlayerWindow window = new AddPlayerWindow
                        {
                            // Dla stworzonego okna ustawiamy kontekst danych (dla wiązania z newPlayer)
                            DataContext = this
                        };
                        // Wyświetlamy nowe okno, tak, że głównie okno jest nieaktywne
                        window.ShowDialog();

                        // We właściwości DialogResult przekazywana jest informacja
                        // czy dodajemy nowego piłkarza, czy też nie
                        if (window.DialogResult == true)
                        {
                            if (newPlayer != null)
                            {
                                // Dodaj piłkarza

                                listOfPlayers.Add(new PlayerViewModel(newPlayer.Name));
                                if (listOfPlayers[listOfPlayers.Count - 1].Name == null)
                                {
                                    displayedPlayer.Name = "Wrong Nickname";
                                    displayedPlayer.Stats = null;
                                    listOfPlayers.RemoveAt(listOfPlayers.Count - 1);
                                }
                            }
                        }
                    }, argument => true);
                return addPlayerCommand;
            }
        }

        /// <summary>
        /// Własność publiczna udostępniąjąca polecenie dodanie nowego logu
        /// </summary>
        public RelayCommand AddLog
        {
            get
            {
                if (addLogCommand == null)
                    addLogCommand = new RelayCommand(argument =>
                    {
                        if (SelectedPlayer != null)
                            SelectedPlayer.AddLog();
                    },
                    argument => true);
                return addLogCommand;
            }
        }

        /// <summary>
        /// Własność publiczna udostępniąjąca polecenie usunięcia ostatniego logu
        /// </summary>
        public RelayCommand DeleteLastLog
        {
            get
            {
                if (deleteLastLogCommand == null)
                    deleteLastLogCommand = new RelayCommand(argument =>
                    {
                        if (SelectedPlayer != null)
                            SelectedPlayer.DeleteLastLog();
                    },
                    argument => true);
                return deleteLastLogCommand;
            }
        }
        #endregion
    }
}
