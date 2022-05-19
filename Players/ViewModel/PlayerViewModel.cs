using System.Collections.Generic;
using Player.Model;
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

        private int log=0;

        private string stats_string;


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

        public int Log
        {
            get {
                Change_Stats_string();
                return log; }
            set {
                Change_Stats_string();
                log = value; onPropertyChanged(nameof(Log)); }
        }


        #endregion

        public override string ToString()
        {
            return mPlayer.ToString();
        }

        public void Change_Stats_string()
        {
            if (log > 0)
            {
                stats_string = mPlayer.Stats[log - 1].ToString();
            }
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
        public PlayerViewModel(string name)
        {
            mPlayer = new Player(name);
            description = this.ToString();
        }

        #endregion
    }
}
