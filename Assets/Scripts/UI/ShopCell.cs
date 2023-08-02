using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

namespace BeastMaster
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Button))]
    public class ShopCell : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _price;

        private Image _icon;
        private Button _button;

        private ItemsData _itemsData;

        private void Awake()
        {
            _icon = GetComponent<Image>();
            _button = GetComponent<Button>();
        }

        public void InitializeData(ItemsData items)
        {
            _itemsData = items;
        }

        public void SetItem(ShopItem item)
        {
            _icon.sprite = item.Icon;
            _button.onClick.RemoveAllListeners();
            _price.text = item.Cost.ToString();
            _button.onClick.AddListener(delegate { TryBuyCurrentItem(item); });
        }

        public void SetRandomItem()
        {
            SetItem(_itemsData.GetRandomItem());
        }

        private void TryBuyCurrentItem(ShopItem item)
        {
            if (item.TryBuy())
            {
                SetRandomItem();
            }
        }
    }
}