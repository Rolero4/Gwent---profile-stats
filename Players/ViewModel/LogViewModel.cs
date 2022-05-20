//using System;
//using System.Collections.Generic;
//using System.Text;
//using Player.Model;
//using Players;

//namespace Player.Model
//{
//    public class LogViewModel : BaseViewModel
//    {
//        #region Prywatne pola

//        // prywatne pole trzymające informacje o piłkarzu
//        private Statistics mLog;

//        // Opis piłkarza w postaci stringa
//        private string description;

//        private string date;

//        private string url;


//        #endregion

//        #region Publiczne własności


//        public string Description
//        {
//            get { return this.ToString(); }
//            set { description = value; onPropertyChanged(nameof(Description)); }
//        }


//        public string Date
//        {
//            get { return date; }
//            set { date = value; onPropertyChanged(nameof(Date)); }
//        }

//        public string Url
//        {
//            get { return url; }
//            set { url = value; onPropertyChanged(nameof(Url)); }
//        }


//        #endregion

//        public override string ToString()
//        {
//            return mLog.ToString();
//        }



//        #region Konstruktory

//        /// <summary>
//        /// Konstruktor domniemany
//        /// </summary>
//        public LogViewModel()
//        {
//            mLog = new Statistics();
//            date = mLog.Date.ToString();
//            description = this.ToString();
//        }

//        /// <summary>
//        /// Konstruktor z parametrami
//        /// </summary>
//        public LogViewModel(string url)
//        {
//            mLog = new Statistics(url);
//            date = mLog.Date.ToString();
//            Url = url;
//            description = this.ToString();
//        }

//        #endregion
//    }
//}
