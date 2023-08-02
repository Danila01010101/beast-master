using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BeastMaster
{
    public class RerollButton : MonoBehaviour
    {
        [SerializeField] private ShopWindow _shopWindow;
        [SerializeField] private Button _rerollButton;
        [SerializeField] private TextMeshProUGUI _upgradeCostText;
        [SerializeField] private int _rerollCostIncreasement = 10;

        private int _currentRerollCost;

        private void Awake()
        {
            _rerollButton.onClick.AddListener(delegate { TryBuyCellsUpgrade(); });
            ResetUpgradeCost();
        }

        private void TryBuyCellsUpgrade()
        {
            if (Wallet.Instance.TryBuy(_currentRerollCost))
            {
                _shopWindow.UpdateCells();
                _currentRerollCost += _rerollCostIncreasement;
                UpdateRerollCost();
            }
        }

        private void ResetUpgradeCost()
        {
            _currentRerollCost = _rerollCostIncreasement;
            UpdateRerollCost();
        }

        private void UpdateRerollCost()
        {
            _upgradeCostText.text = "- " + _rerollCostIncreasement;
        }

        private void OnEnable()
        {
            _shopWindow.ShopOppened += ResetUpgradeCost;
        }

        private void OnDisable()
        {
            _shopWindow.ShopOppened -= ResetUpgradeCost;
        }
    }
}
