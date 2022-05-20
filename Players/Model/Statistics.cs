using System;
using System.Collections.Generic;
using Players.Model;

namespace Player.Model
{
    [Serializable]
    public class Statistics
    {
        public List<string[]> Statistcs { get; set; }
        public DateTime Date;


        public Statistics()
        {
            Statistcs = new List<string[]>();
            Date = DateTime.Now;
        }

        //List: [mmr, position], [wins, losses, draws] [winrate, lei], sk[matches, wins, wr], sc[], mo[], nr[], ng[], sy[]
        public Statistics(string url)
        {
            //gettings stats from method
            Statistcs = new List<string[]>();
            var stats_to_edit = Scrapper.GetStats(url);
            if (stats_to_edit.Contains("error"))
            {
                string[] statistcs = new string[1] { "error" };
                Statistcs.Add(statistcs);
                var src = DateTime.Now;
                var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, src.Second);
                Date = hm;
            }
            else
            {
                //mmr, position then global stats of wins/losses/draws in current season
                string[] mmr_position = new string[2] { stats_to_edit[15], stats_to_edit[16] };
                Statistcs.Add(mmr_position);
                string[] matches_stats = new string[3] { stats_to_edit[6], stats_to_edit[7], stats_to_edit[8], };
                Statistcs.Add(matches_stats);

                double wr = 0.0;
                if ((double.Parse(stats_to_edit[6]) + double.Parse(stats_to_edit[7]) + double.Parse(stats_to_edit[8])) != 0)
                {
                    wr = Math.Round((double.Parse(stats_to_edit[6]) * 100) / (double.Parse(stats_to_edit[6]) + double.Parse(stats_to_edit[7]) + double.Parse(stats_to_edit[8])), 2);
                }
                //wr and lei
                string[] wr_lei = new string[2] { wr.ToString() + "%", "Na" };
                Statistcs.Add(wr_lei);

                //factions matches, wins and wr
                for (int i = 0; i < 6; i++)
                {
                    string[] faction = new string[3] { stats_to_edit[i], stats_to_edit[i + 9], "0%" };
                    if (faction[0] != "0")
                    {
                        string faction_wr = Math.Round((double.Parse(faction[1]) * 100 / double.Parse(faction[0])), 2).ToString() + "%";
                        faction[2] = faction_wr;
                    }
                    Statistcs.Add(faction);
                }

                // real lei(all factions)
                int counter = 0;
                for (int i = 3; i < Statistcs.Count; i++)
                {
                    if (int.Parse(Statistcs[i][0]) >= 25)
                    {
                        counter++;
                    }
                }
                if (counter >= 4)
                {
                    string lei = Math.Round((double.Parse(Statistcs[0][0]) - 9600) / Math.Sqrt(double.Parse(stats_to_edit[6]) + double.Parse(stats_to_edit[7]) + double.Parse(stats_to_edit[8])), 2).ToString();
                    Statistcs[2][1] = lei;
                }

                //date of log
                var src = DateTime.Now;
                var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, src.Second);

                Date = hm;
            }

        }

        //public override string ToString()
        //{
        //    string my_return = "";

        //    my_return += "Position: " + Statistcs[0][1] + "   ";
        //    my_return += "Mmr: " + Statistcs[0][0] + "\n";

        //my_return += "Wins: " + Statistcs[1][0] + "   ";
        //    my_return += "Losses: " + Statistcs[1][1] + "   ";
        //    my_return += "Draws: " + Statistcs[1][2] + "\n";

        //    my_return += "Winrate: " + Statistcs[2][0] + "   ";
        //    my_return += "Lei: " + Statistcs[2][1] + "\n";

//        string[] factions = new string[6] { "Skellige: ", "Scoia'tael: ", "Monsters: ", "Northern Realms: ", "Nilfgaard: ", "Syndicate: " };

//            for (int i = 3; i<Statistcs.Count; i++)
//            {
//                my_return += factions[i - 3];
//                //faction stats
//                for (int j = 0; j< 3; j++)
//                {
//                    if (j == 0)
//                    {
//                        my_return += " matches: " + Statistcs[i][j];
//                    }
//                    else if (j == 1)
//                    {
//                        my_return += " wins: " + Statistcs[i][j];
//                    }
//                    else
//{
//    my_return = " winrate:" + Statistcs[i][j];
//}
//                }
//                my_return += "\n";
//            }
        //    my_return += "Date of log: " + Date.ToString();
        //    return my_return;
        //}

        public override string ToString()
        {
            string my_return = "";

            my_return += Date.ToString() + "\n";

            my_return += "Position: " + Statistcs[0][1] + "   ";
            my_return += "Mmr: " + Statistcs[0][0] + "\n";

            my_return += "Wins: " + Statistcs[1][0] + "   ";
            my_return += "Losses: " + Statistcs[1][1] + "   ";
            my_return += "Draws: " + Statistcs[1][2] + "\n";

            my_return += "Winrate: " + Statistcs[2][0] + "   ";
            my_return += "Lei: " + Statistcs[2][1] + "\n";

            my_return += "Monsters: " + Statistcs[3][0] + " matches, "+ Statistcs[3][1] + " wins, " + Statistcs[3][2] + " winrate " + "\n";
            my_return += "Nilfgaard: " + Statistcs[4][0] + " matches, " + Statistcs[4][1] + " wins, " + Statistcs[4][2] + " winrate " + "\n";
            my_return += "Northern Realms: " + Statistcs[5][0] + " matches, " + Statistcs[5][1] + " wins, " + Statistcs[5][2] + " winrate " + "\n";
            my_return += "Scoia'tael: " + Statistcs[6][0] + " matches, " + Statistcs[6][1] + " wins, " + Statistcs[6][2] + " winrate " + "\n";
            my_return += "Skellige: " + Statistcs[7][0] + " matches, " + Statistcs[7][1] + " wins, " + Statistcs[7][2] + " winrate " + "\n";
            my_return += "Syndicate: " + Statistcs[8][0] + " matches, " + Statistcs[8][1] + " wins, " + Statistcs[8][2] + " winrate " + "\n";

            return my_return;
        }

    }
}

//stats with ints
//_statistcs = new List<int[]>();
//var stats_to_edit = Scrapper.GetStats(url);
//int[] mmr_position = new int[2] { int.Parse(stats_to_edit[15]), int.Parse(stats_to_edit[16]) };
//_statistcs.Add(mmr_position);
//int[] matches_stats = new int[3] { int.Parse(stats_to_edit[0]), int.Parse(stats_to_edit[1]), int.Parse(stats_to_edit[2]), };
//_statistcs.Add(matches_stats);
//int[] wr_lei = new int[2] { int.Parse(stats_to_edit[0]) / (int.Parse(stats_to_edit[0]) + int.Parse(stats_to_edit[1]) + int.Parse(stats_to_edit[2])), int.Parse(stats_to_edit[16]) };
//_statistcs.Add(wr_lei);
//int[] skellige = new int[2] { int.Parse(stats_to_edit[5]), int.Parse(stats_to_edit[13]) };
//int[] scoia = new int[2] { int.Parse(stats_to_edit[6]), int.Parse(stats_to_edit[12]) };
//int[] monsters = new int[2] { int.Parse(stats_to_edit[7]), int.Parse(stats_to_edit[9]) };
//int[] nrealms = new int[2] { int.Parse(stats_to_edit[4]), int.Parse(stats_to_edit[11]) };
//int[] nilfgaard = new int[2] { int.Parse(stats_to_edit[8]), int.Parse(stats_to_edit[10]) };
//int[] syndicate = new int[2] { int.Parse(stats_to_edit[3]), int.Parse(stats_to_edit[14]) };

//var src = DateTime.Now;
//var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, 0);