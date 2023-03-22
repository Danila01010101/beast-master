using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace BeastMaster.Saves
{
    public class DataSaver : MonoBehaviour
	{
        private GameData _data;
        private const string FILENAME = "/data.gd";

        #region Get/Set Methods

        public float MainVolume 
        {
            get { return _data.MainVolume; }
            set { SetValueInBounds(0, 1, value, out _data.MainVolume); }
        }
        public float MusicVolume
        {
            get { return _data.MusicVolume; }
            set { SetValueInBounds(0, 1, value, out _data.MusicVolume); }
        }
        public float EffectsVolume
        {
            get { return _data.EffectsVolume; }
            set { SetValueInBounds(0, 1, value, out _data.EffectsVolume); }
        }

        #endregion

        public static DataSaver Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance == this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _data = DataFileLoader.Load(FILENAME);
        }

        public void Save()
        {
            if (_data != null)
            {
                DataFileSaver.Save(FILENAME, _data);
            }
        }

        private void SetValueInBounds<T>(T min, T max, T valueToSet, out T settableValue) where T : IComparable
        {
            if (valueToSet.CompareTo(max) <= 0 || valueToSet.CompareTo(min) >= 0)
            {
                settableValue = valueToSet;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}