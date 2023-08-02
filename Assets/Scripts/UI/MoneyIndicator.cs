using TMPro;
using UnityEngine;

namespace BeastMaster
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class MoneyIndicator : MonoBehaviour
    {
        private TextMeshProUGUI _coinsText;

        private void Awake()
        {
            _coinsText = GetComponent<TextMeshProUGUI>();
        }

        private void UpdateText()
        {
            _coinsText.text = Wallet.Instance.MoneyAmount.ToString();
        }

        private void OnEnable()
        {
            UpdateText();
            Wallet.Instance.MoneyAmountChanged += UpdateText;
        }

        private void OnDisable()
        {
            Wallet.Instance.MoneyAmountChanged -= UpdateText;
        }
    }
}
