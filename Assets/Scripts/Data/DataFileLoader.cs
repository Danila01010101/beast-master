using BeastMaster.Saves;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace BeastMaster
{
    public class DataFileLoader
    {
        public static GameData Load(string fileName)
        {
            if (File.Exists(Application.persistentDataPath + fileName))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + fileName, FileMode.Open);
                var savedGame = (GameData)bf.Deserialize(file);
                file.Close();

                return savedGame;
            }

            return new GameData();
        }
    }
}