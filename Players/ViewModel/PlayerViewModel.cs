using System.Collections.Generic;
using Players.Model;
using Players.Models;

namespace Players
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

        public int Logs
        {
            get
            {
                return mPlayer.Logs;
            }
            set
            {
                mPlayer.Logs = value;
                onPropertyChanged(nameof(Logs));
            }
        }


        public List<Statistics> Stats
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

        public override string ToString()
        {
            return mPlayer.ToString();
        }


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
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="weight"></param>
        /// <param name="age"></param>
        /// <param name="pathToImage"></param>
        public PlayerViewModel(string name)
        {
            mPlayer = new Player(name);
            description = this.ToString();
        }

        #endregion
    }
}
