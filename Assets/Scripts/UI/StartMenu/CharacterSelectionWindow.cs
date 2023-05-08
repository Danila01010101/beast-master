using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BeastMaster
{
    public class CharacterSelectionWindow : UIWindow
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Transform _startPosition;
        [SerializeField] private Player _characterPrefab;
        [SerializeField] private List<CharacterButton> _characterButtons;

        private CharacterData _characterData;

        private void Start()
        {
            _startButton.gameObject.SetActive(false);

            foreach (CharacterButton button in _characterButtons)
            {
                button.GetButton().onClick.AddListener(delegate { SelectCharacter(button.CharacterData); });
            }
        }

        public void SelectCharacter(CharacterData data)
        {
            _characterData = data;
            if (!_startButton.gameObject.activeSelf)
                _startButton.gameObject.SetActive(true);
        }

        private void SpawnCharacter()
        {
            Player player = Instantiate(_characterPrefab, _startPosition.position, _characterPrefab.transform.rotation);
            player.Initialize(_characterData);
        }

        private void OnEnable()
        {
            LevelStarter.LevelStarted += SpawnCharacter;
        }

        private void OnDisable()
        {
            LevelStarter.LevelStarted -= SpawnCharacter;
        }

        public override void Initialize()
        {
            _startButton.onClick.AddListener(delegate { UIWindowManager.Show<GameUI>(); });
            _backButton.onClick.AddListener(delegate { UIWindowManager.ShowLast(); });
        }
    }
}