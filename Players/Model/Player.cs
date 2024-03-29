﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using Player.Model;

namespace Player.Model
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

        public ObservableCollection<Statistics> Stats { get; set; }
        #endregion

        #region Konstruktory

        /// <summary>
        /// Konstruktor domniemany
        /// </summary>
        public Player()
        {
            Name = "";
            Url = "https://www.playgwent.com/en/profile/";
            Stats = new ObservableCollection<Statistics>();
        }

        public Player(string name)
        {
            if (name != null)
            {
                Name = name;
                Url = "https://www.playgwent.com/en/profile/" + name;
                Stats = new ObservableCollection<Statistics>();
                AddLog();
            }
        }

        public Player(Player player, Statistics stats)
        {
            Name = player.Name;
            Url = player.Url;
            Stats = player.Stats;
            Stats.Add(stats);
        }

        //Konstruktor usuwający ostatni elemnt listy
        public Player(Player player)
        {
            Name = player.Name;
            Url = player.Url;
            Stats = player.Stats;
            this.Stats.RemoveAt(Stats.Count - 1);
        }


        #endregion

        public void AddLog()
        {
            var stats_object = new Statistics(Url);
            if (stats_object.Statistcs[0][0] == "error")
            {
                this.Name = null;
            }
            else
            {
                Stats.Add(stats_object);
            }
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
