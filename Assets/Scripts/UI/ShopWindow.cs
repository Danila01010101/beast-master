using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BeastMaster
{
    public class ShopWindow : UIWindow
    {
        [Header("Buttons")]
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _backButton;
        [Header("Cells")]
        [SerializeField] private List<ShopCell> _shopCells;
        [Header("Items")]
        [SerializeField] private ItemsData _items;

        public override void Initialize()
        {
            _startButton.onClick.AddListener(delegate { UIWindowManager.Show<GameUI>(); });
            _backButton.onClick.AddListener(delegate { UIWindowManager.ShowLast(); });
            foreach (ShopCell cell in _shopCells)
            {
                cell.InitializeData(_items);
            }
        }

        override public void Show()
        {
            base.Show();
            UpdateCells();
        }

        public void UpdateCells()
        {
            foreach (ShopCell cell in _shopCells)
            {
                cell.SetItem(_items.GetRandomItem());
            }
        }
    }
}