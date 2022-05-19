using System.Collections.Generic;
using Players.Models;

namespace Players.Model
{
    /// <summary>
    /// Klasa Player opisująca piłkarza
    /// </summary>
    public class Player
    {
        #region Prywatne pola

        //string name;
        //string url;
        //List<Statistics> stats;


        #endregion

        #region Publiczne własności

        public string Name { get; set; }
        //{ get { return firstName; } set { firstName = value; } }

        public string Url { get; set; }
        //{ get { return lastName; } set { lastName = value; } }

        public List<Statistics> Stats { get; set; }

        public int Log { get; set; }

        #endregion

        #region Konstruktory

        /// <summary>
        /// Konstruktor domniemany
        /// </summary>
        public Player()
        {
            Name = "";
            Url = "https://www.playgwent.com/en/profile/";
            Stats = new List<Statistics>();
            Log = 0;
        }

        public Player(string name)
        {
            Name = name;
            Url = "https://www.playgwent.com/en/profile/" + name;
            Stats = new List<Statistics>();
            AddLog();
            Log = 0;
        }

        #endregion

        public void AddLog()
        {
            var stats_object = new Statistics(Url);
            Stats.Add(stats_object);
        }


        /// <summary>
        /// Npisana metoda ToString()
        /// w postaci tekstu
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name + " had " + Stats.Count + " log(s) ";
        }




        public string Stats_ToString()
        {
            string str = "";
            foreach (Statistics stat in Stats)
            {
                str += stat.ToString();
            }
            return str;
        }

        //public string ToString(int x)
        //{
        //    if( x > Logs-1){
        //        return Stats[Logs-1].ToString();

        //    }
        //    else
        //    {
        //        return Stats[x].ToString();
        //    }
        //}
    }
}
