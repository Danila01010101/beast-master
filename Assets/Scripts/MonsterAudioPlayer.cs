using UnityEngine;

namespace BeastMaster
{
	public class MonsterAudioPlayer : MonoBehaviour
	{
		private AudioSource _deathAudioSource;
		private AudioSource _hitAudioSource;

		public enum Sound { Death, Hit }

        private void Start()
        {
			var audioGameObject = new GameObject("Audio");
			audioGameObject.transform.parent = transform;

			_deathAudioSource = audioGameObject.AddComponent<AudioSource>();
			_hitAudioSource = audioGameObject.AddComponent<AudioSource>();
        }

		public void Initialize(AudioClip deathSound, AudioClip hitSound)
		{
            _deathAudioSource.clip = deathSound;
			_hitAudioSource.clip = hitSound;
        }

        public void PlaySound(Sound sound)
		{
			switch(sound)
			{
				case Sound.Death:
					_deathAudioSource.Play();
					break;
				case Sound.Hit:
					_hitAudioSource.Play();
					break;
			}
		}
	}
}