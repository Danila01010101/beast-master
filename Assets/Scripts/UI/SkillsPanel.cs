using System;
using System.Collections.Generic;
using UnityEngine;

namespace BeastMaster
{
    public class SkillsPanel : MonoBehaviour
    {
        [SerializeField] private List<SkillIndicator> _skillIndicators;

        private int _usedIndicatorsCounter = 0;

        public bool HaveFreeIndicators() => _usedIndicatorsCounter < _skillIndicators.Count;

        private void Awake()
        {
            SpellItem.CheckCanBuy += HaveFreeIndicators;
        }

        public SkillIndicator GetIndicator()
        {
            if (_usedIndicatorsCounter > _skillIndicators.Count)
                throw new IndexOutOfRangeException();

            return _skillIndicators[_usedIndicatorsCounter++];
        }

        private void OnDestroy()
        {
            SpellItem.CheckCanBuy -= HaveFreeIndicators;
        }
    }
}