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

		private Queue<LevelData> _levelsStack = new Queue<LevelData>();

		public static Action LevelEnded;
		public static Action<LevelData> LevelStarted;

        private void Awake()
        {
			foreach (LevelData levelData in _levelDatas)
			{
				_levelsStack.Enqueue(levelData);
			}
			foreach (Button button in _startButtons)
            {
                button.onClick.AddListener(StartLevel);
            }
        }

        public void StartLevel()
		{
			LevelData currentLevel = _levelsStack.Dequeue();
            LevelStarted?.Invoke(currentLevel);
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
			LevelEnded?.Invoke();
        }
    }
}