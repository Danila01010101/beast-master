using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BeastMaster
{
    public class CharacterSelectionWindow : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Transform _startPosition;
        [SerializeField] private Player _characterPrefab;
        [SerializeField] private List<CharacterButton> _characterButtons;

        private CharacterData _characterData;

        private void Start()
        {
            _startButton.gameObject.SetActive(false);
            _startButton.onClick.AddListener(StartGame);

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

        private void StartGame()
        {
            Player player = Instantiate(_characterPrefab, _startPosition.position, _characterPrefab.transform.rotation);
            player.Initialize(_characterData);
        }
    }
}