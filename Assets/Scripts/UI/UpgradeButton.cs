using System;
using UnityEngine;
using UnityEngine.UI;

namespace BeastMaster
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Image))]
    public class UpgradeButton : MonoBehaviour
	{
		private Button _button;
        private Image _image;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
        }

        public void Initialize(Action upgradeAction, Sprite icon)
		{
			_button.onClick.RemoveAllListeners();
			_button.onClick.AddListener(delegate { upgradeAction?.Invoke(); });
            _image.sprite = icon;
		}
	}
}