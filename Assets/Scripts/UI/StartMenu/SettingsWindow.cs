using BeastMaster.Saves;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace BeastMaster
{
    public class SettingsWindow : UIWindow
    {
        [SerializeField] private Button _back;
        [Header("Sliders")]
        [SerializeField] private Slider _mainVolumeSlider;
        [SerializeField] private Slider _effectsVolumeSlider;
        [SerializeField] private Slider _musicVolumeSlider;

        public void ChangeMainVolume()
        {
            DataSaver.Instance.MainVolume = _mainVolumeSlider.value;
        }

        public void ChangeEffectsVolume()
        {
            DataSaver.Instance.EffectsVolume = _effectsVolumeSlider.value;
        }

        public void ChangeMusicVolume()
        {
            DataSaver.Instance.MusicVolume = _musicVolumeSlider.value;
        }

        public override void Initialize()
        {
            _mainVolumeSlider.value = DataSaver.Instance.MainVolume;
            _effectsVolumeSlider.value = DataSaver.Instance.EffectsVolume;
            _musicVolumeSlider.value = DataSaver.Instance.MusicVolume;

            _back.onClick.AddListener( delegate { UIWindowManager.ShowLast(); });
        }
    }
}