using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BeastMaster
{
    [RequireComponent(typeof(Button))]
    public class SkillIndicator : MonoBehaviour
    {
        [SerializeField] private Image _progressIndicator;
        [SerializeField] private Image _icon;
        [SerializeField] private Image _lockedImage;

        public void SetIcon(Sprite sprite)
        {
            _icon.sprite = sprite;
            _lockedImage.enabled = false;
            _progressIndicator.fillAmount = 0;
        }

        public void ShowReload(float lenght)
        {
            StopAllCoroutines();
            StartCoroutine(ReloadingAnimation(lenght));
        }

        private IEnumerator ReloadingAnimation(float lenght)
        {
            float timer = 0;
            float fillAmount = 0;
            _progressIndicator.fillAmount = fillAmount;
            float speed = 1 / lenght;
            while (timer < lenght)
            {
                timer += Time.deltaTime;
                fillAmount += speed * Time.deltaTime;
                _progressIndicator.fillAmount = fillAmount;
                yield return null;
            }
        }
    }
}
