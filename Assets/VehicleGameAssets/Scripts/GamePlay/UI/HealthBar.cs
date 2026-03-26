using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Alchemy.Inspector;

namespace VehicleGame.Gameplay.UI
{
    public class HealthBar : MonoBehaviour
    {
        [Header("UI")]
        public Image fill;
        public Image damageDelayFill;

        [Header("Settings")]
        public float damageDelay = 0.5f;
        public float damageSpeed = 0.5f;
        public float healSpeed = 0.25f;

        public float current = 100;
        public float max = 100;

        private float currentFill;

        private void Start()
        {
            SetHealth(current, max);
        }
        [Button]
        public void SetHealth(float current, float max)
        {
            this.current = current;
            this.max = max;
            float targetFill = Mathf.Clamp01(current / max);

            fill.DOKill();
            damageDelayFill.DOKill();

            fill.DOFillAmount(targetFill, healSpeed).SetEase(Ease.OutCubic);

            if (targetFill < currentFill)
            {
                damageDelayFill
                    .DOFillAmount(targetFill, damageSpeed)
                    .SetDelay(damageDelay)
                    .SetEase(Ease.OutQuad);
            }
            else
            {

                damageDelayFill.DOFillAmount(targetFill, healSpeed).SetEase(Ease.OutCubic);
            }

            currentFill = targetFill;
        }
    }
}
