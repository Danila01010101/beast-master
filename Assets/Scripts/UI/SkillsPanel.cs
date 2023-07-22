using System;
using System.Collections.Generic;
using UnityEngine;

namespace BeastMaster
{
    public class SkillsPanel : MonoBehaviour
    {
        [SerializeField] private List<SkillIndicator> _skillIndicators;

        private int _usedIndicatorsCounter = 0;

        public SkillIndicator GetIndicator()
        {
            if (_usedIndicatorsCounter > _skillIndicators.Count)
                throw new NullReferenceException();

            return _skillIndicators[_usedIndicatorsCounter++];
        }
    }
}