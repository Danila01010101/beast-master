using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BeastMaster
{
    public class LevelStarter : MonoBehaviour
	{
		[SerializeField] private Button _startButton;
		[SerializeField] private LevelData _levelData;
		[SerializeField] private TextMeshProUGUI _counterText;

		public static Action LevelEnded;
		public static Action<LevelData> LevelStarted;

        private void Awake()
        {
            _startButton.onClick.AddListener(StartLevel);
        }

        public void StartLevel()
		{
            LevelStarted?.Invoke(_levelData);
			StartCoroutine(LevelEndCounting(_levelData.LevelLenght));
        }

		private IEnumerator LevelEndCounting(float lenght)
        {
            _counterText.gameObject.SetActive(true);
			float endCounter = lenght + 1;
			while (endCounter >= 0)
			{
				int minutes = (int)(endCounter / 60);
				int seconds = (int)(endCounter % 60);
				_counterText.text = String.Format("{0} : {1}", minutes, seconds);
				endCounter -= Time.deltaTime;
				yield return null;
            }
            _counterText.gameObject.SetActive(false);
			LevelEnded?.Invoke();
        }
    }
}