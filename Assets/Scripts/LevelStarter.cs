using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BeastMaster
{
    public class LevelStarter : MonoBehaviour
	{
		[SerializeField] private List<Button> _startButtons;
		[SerializeField] private List<LevelData> _levelDatas;
		[SerializeField] private TextMeshProUGUI _counterText;

		private Queue<LevelData> _levelsQueue = new Queue<LevelData>();

		public static Action LevelEnded;
		public static Action LevelStarted;
		public static Action GameFinished;
		public static Action<LevelData> LevelDataSelected;

        private void Awake()
        {
			foreach (LevelData levelData in _levelDatas)
			{
				_levelsQueue.Enqueue(levelData);
			}
			foreach (Button button in _startButtons)
            {
                button.onClick.AddListener(StartLevel);
            }
        }

        public void StartLevel()
		{
			LevelData currentLevel = _levelsQueue.Dequeue();
			LevelStarted?.Invoke();
            LevelDataSelected?.Invoke(currentLevel);
			StartCoroutine(LevelEndCounting(currentLevel.LevelLenght));
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
			if (_levelsQueue.Count != 0)
            {
                LevelEnded?.Invoke();
            }
			else
			{
				GameFinished?.Invoke();
			}
        }

        private void OnEnable()
        {
			Player.GameOver += StopAllCoroutines;
        }

        private void OnDisable()
        {
            Player.GameOver -= StopAllCoroutines;
        }
    }
}