using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BeastMaster
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Button))]
    public class ShopCell : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _price;

        private Image _icon;
        private Button _button;

        private void Awake()
        {
            _icon = GetComponent<Image>();
            _button = GetComponent<Button>();
        }

        public void SetItem(ShopItem item)
        {
            _icon.sprite = item.Icon;
            _button.onClick.RemoveAllListeners();
            _price.text = item.Cost.ToString();
            _button.onClick.AddListener(item.TryBuy);
        }
    }
}