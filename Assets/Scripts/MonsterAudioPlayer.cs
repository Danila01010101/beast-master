using BeastMaster.Saves;
using UnityEngine;

namespace BeastMaster
{
    public class MonsterAudioPlayer : MonoBehaviour
	{
		private AudioSource _hitAudioSource;
		private AudioClip _deathSound;

		private GameObject _audioGameObject;
		private float _volume;

		public enum Sound { Death, Hit }

		public void Initialize(AudioClip deathSound, AudioClip hitSound)
        {
            _audioGameObject = new GameObject("MonsterAudio");
            _audioGameObject.transform.SetParent(transform);
			_audioGameObject.transform.localPosition = Vector3.zero;

			_volume = DataSaver.Instance.EffectsVolume * DataSaver.Instance.MainVolume;
            _deathSound = deathSound;
            _hitAudioSource = _audioGameObject.AddComponent<AudioSource>();
            _hitAudioSource.clip = hitSound;
            _hitAudioSource.volume = _volume;
        }

        public void PlaySound(Sound sound)
		{
			switch(sound)
			{
				case Sound.Death:
					AudioSource.PlayClipAtPoint(_deathSound, _audioGameObject.transform.position, _volume);
					break;
				case Sound.Hit:
					_hitAudioSource.Play();
					break;
			}
		}
    }
}