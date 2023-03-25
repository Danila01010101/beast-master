using System;
using UnityEngine;

namespace BeastMaster
{
    [RequireComponent(typeof(PlayerMonsters))]
    public class Player : MonoBehaviour
    {
        private PlayerMonsters _monsters;
        private Animator _animator;

        public static Action CharacterSpawned;

        public void Initialize(CharacterData data)
        {
            _animator = Instantiate(data.CharacterAnimator, transform);
            _monsters = GetComponent<PlayerMonsters>();
            _monsters.Initialize(data);
            CharacterSpawned?.Invoke();
        }
    }
}