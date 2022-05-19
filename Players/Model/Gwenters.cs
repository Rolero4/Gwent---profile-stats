using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace Player.Model
{
    [Serializable]
    [XmlRoot("Players")]

    public class Gwenters
    {
        public ObservableCollection<Player> GwentersList;

        public Gwenters()
        {
            GwentersList = new ObservableCollection<Player>();
        }

        public Gwenters(Player player)
        {
            GwentersList = new ObservableCollection<Player>
            {
                player
            };
        }

        public Gwenters(ObservableCollection<Player> players)
        {
            GwentersList = players;
        }


        public ObservableCollection<string> List_of_Players()
        {
            var my_return = new ObservableCollection<string>();
            foreach (Player p in GwentersList)
            {
                my_return.Add(p.Name);
            }

            return my_return;
        }
        public void Add_Player(Player player)
        {
            GwentersList.Add(player);
        }

        public Player Find(string name)
        {
            for (int i = 0; i < GwentersList.Count; i++)
            {
                Player p = GwentersList[i];
                if (p.Name == name)
                    return p;
            }
            return null;
        }


        public void Serialize()
        {
            Stream stream = File.Create(Environment.CurrentDirectory + "\\Data/listOfPlayers.txt");
            var xmlser = new XmlSerializer(typeof(Gwenters));
            xmlser.Serialize(stream, this);
            stream.Close();
        }

        public void Deserialize()
        {
            var xmlser = new XmlSerializer(typeof(Gwenters));
            if (File.Exists(Environment.CurrentDirectory + "\\Data/listOfPlayers.txt"))
            {
                using FileStream fileStream = new FileStream(Environment.CurrentDirectory + "\\Data/listOfPlayers.txt", FileMode.Open);
                var obj = (Gwenters)xmlser.Deserialize(fileStream);
                GwentersList = obj.GwentersList;
            }
            else
            {
                GwentersList = new ObservableCollection<Player>();
            }
        }


    }
}
