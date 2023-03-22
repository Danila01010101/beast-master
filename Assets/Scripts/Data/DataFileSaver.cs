using BeastMaster.Saves;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace BeastMaster
{
	public class DataFileSaver : MonoBehaviour
    {
        public static void Save(string fileName, GameData gameData)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + fileName);
            bf.Serialize(file, gameData);
            file.Close();

            Debug.Log($"Saved: {Application.persistentDataPath}{fileName}");
        }
    }
}