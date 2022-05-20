using System.Collections.ObjectModel;
using Players;

namespace Player.Model
{
    /// <summary>
    /// Klasa modelu widoku udostępniąjąca widokowi
    /// odpowiednie własności (np. Imie wybranego piłkarza)
    /// </summary>
    public class PlayerViewModel : BaseViewModel
    {
        #region Prywatne pola

        // prywatne pole trzymające informacje o piłkarzu
        private Player mPlayer;

        // Opis piłkarza w postaci stringa
        private string description;


        #endregion

        #region Publiczne własności

        public string Name
        {
            get
            {
                return mPlayer.Name;
            }
            set
            {
                mPlayer.Name = value;
                onPropertyChanged(nameof(Name));
            }
        }

        public string Url
        {
            get
            {
                return mPlayer.Url;
            }
            set
            {
                mPlayer.Url = value;
                onPropertyChanged(nameof(Url));
            }
        }

        public ObservableCollection<Statistics> Stats
        {
            get
            {
                return mPlayer.Stats;
            }
            set
            {
                mPlayer.Stats = value;
                onPropertyChanged(nameof(Stats));
            }
        }

        public string Description
        {
            get { return this.ToString(); }
            set { description = value; onPropertyChanged(nameof(Description)); }
        }

        #endregion

        #region Metody
        public override string ToString()
        {
            return mPlayer.ToString();
        }

        public void AddLog()
        {
            var s = new Statistics(mPlayer.Url);
            mPlayer = new Player(mPlayer, s);
            Description = this.ToString();
        }

        public void DeleteLastLog()
        {
            if (mPlayer.Stats.Count != 0)
            {
                mPlayer = new Player(mPlayer);
                Description = this.ToString();
            }
        }

        #endregion

        #region Konstruktory

        /// <summary>
        /// Konstruktor domniemany
        /// </summary>
        public PlayerViewModel()
        {
            mPlayer = new Player();
            description = this.ToString();
        }

        /// <summary>
        /// Konstruktor z parametrami
        /// </summary>
        public PlayerViewModel(string name)
        {
            mPlayer = new Player(name);
            description = this.ToString();
        }

        #endregion
    }
}
