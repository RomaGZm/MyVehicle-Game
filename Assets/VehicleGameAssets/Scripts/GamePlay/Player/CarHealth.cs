using DG.Tweening;
using UnityEngine;
using VehicleGame.Gameplay.UI;

namespace VehicleGame.Gameplay.Player
{
    public class CarHealth : MonoBehaviour
    {
        [Header("Health")]
        public int maxHealth = 200;
        public int health = 200;

        [Header("Damage Shake")]
        public float punchScale = 0.25f;
        public float duration = 0.25f;
        public int vibrato = 10;
        public float elasticity = 0.8f;

        [SerializeField] private ParticleSystem dieParticle;
        [SerializeField] private HealthBar carHealthBar;
       
        private Vector3 originalScale;
        
        private void Awake()
        {
            originalScale = transform.localScale;
        }

        public void TakeDamage(int value)
        {
            if (GameplayManager.Instance.isPause) return;

            health -= value;
            carHealthBar.SetHealth(health, maxHealth);
            PlayShake();

            if (health <= 0)
            {
                GameplayManager.Instance.SetPause(true);
                Die();
            }
        }
        //Die player event
        private void Die()
        {
            dieParticle.Play(true);
            UIManager.Instance.Lose();

        }
        /// <summary>
        /// Animation shake car
        /// </summary>
        public void PlayShake()
        {
            transform.DOKill();

            transform.localScale = originalScale;

            transform.DOPunchScale(
                new Vector3(punchScale, punchScale, punchScale),
                duration,
                vibrato,
                elasticity
            );
        }
    }

}
