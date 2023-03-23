using BeastMaster.Saves;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace BeastMaster
{
    public class SettingsWindow : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        [Header("Sliders")]
        [SerializeField] private Slider _mainVolumeSlider;
        [SerializeField] private Slider _effectsVolumeSlider;
        [SerializeField] private Slider _musicVolumeSlider;

        private void Awake()
        {
            _mainVolumeSlider.value = DataSaver.Instance.MainVolume;
            _effectsVolumeSlider.value = DataSaver.Instance.EffectsVolume;
            _musicVolumeSlider.value = DataSaver.Instance.MusicVolume;
        }

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

        private void OnEnable()
        {
            _exitButton.onClick.AddListener(DataSaver.Instance.Save);
        }

        private void OnDisable()
        {
            _exitButton.onClick.RemoveListener(DataSaver.Instance.Save);
        }
    }
}