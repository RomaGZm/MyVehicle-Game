using UnityEngine;
using VehicleGame.Gameplay.UI;

namespace VehicleGame.Gameplay.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [Header("Settings")]
        public int maxHealth = 10;
        public int health = 10;
        public bool isDie { get; private set; }

        [Header("Components")]
        [SerializeField] private EnemyAnimation animations;
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private Canvas canvas;
        [SerializeField] private ParticleSystem dieFX;

        private void OnEnable()
        {
            canvas.worldCamera = Camera.main;
            health = maxHealth;
            healthBar.SetHealth(health, maxHealth);
            animations.RandomIdle();
            isDie = false;
            healthBar.gameObject.SetActive(false);
        }
        //Enemy take damage
        public void TakeDamage(int value)
        {
            if (isDie) return;
            health -= value;
            healthBar.gameObject.SetActive(true);
            healthBar.SetHealth(health, maxHealth);
            dieFX.Play(true);

            animations.Hit();
            PopupTextManager.Instance.Show(value.ToString(), transform, 120f, new Vector2(0, 1f), Color.yellow, 60);

            if (health <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            health = 0;
            isDie = true;
            gameObject.SetActive(false);

        }
    }
}

