using System;
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

        public Action ShopOppened;

        public override void Initialize()
        {
            _startButton.onClick.AddListener(delegate { UIWindowManager.Show<GameUI>(false); });
            _backButton.onClick.AddListener(delegate { UIWindowManager.ShowLast(); });
        }

        override public void Show()
        {
            base.Show();
            UpdateCells();
            ShopOppened?.Invoke();
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