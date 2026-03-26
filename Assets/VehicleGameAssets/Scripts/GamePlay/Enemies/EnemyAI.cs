
using UnityEngine;
using VehicleGame.Gameplay.Player;

namespace VehicleGame.Gameplay.Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        [Header("Settings")]
        public float detectDistance = 25f;
        public float moveSpeed = 5f;
        public float rotateSpeed = 8f;
        public float collisionDistance = 1f;
        public int damage = 10;

        [Header("Components")]
        [SerializeField] private EnemyAnimation animations;
        [SerializeField] private EnemyHealth enemyHealth;

        private bool detected;
        private BaseCarController player;

        public void Init()
        {
            detected = false;
        }

        private void OnDisable()
        {
            detected = false;
            transform.position = Vector3.zero;
        }

        public void UpdateDistance(Vector3 playerPos)
        {
            if (enemyHealth.isDie) return;

            float dist = (playerPos - transform.position).sqrMagnitude;

            if (!detected && dist < detectDistance)
            {
                detected = true;
                StartChase();
            }
        }

        private void StartChase()
        {
            player = GameplayManager.Instance.carController;
            animations.Run(true);

        }

        private void Update()
        {
            if (enemyHealth.isDie) return;
            if (!detected || player == null) return;

            float dist = (player.transform.position - transform.position).sqrMagnitude;

            if (dist < collisionDistance)
            {

                enemyHealth.TakeDamage(enemyHealth.maxHealth);
                player.carHealth.TakeDamage(damage);
            }

            MoveTowardsTarget();
        }

        private void MoveTowardsTarget()
        {
            Vector3 dir = player.transform.position - transform.position;
            dir.y = 0;

            if (dir.sqrMagnitude < 0.1f)
                return;

            Quaternion targetRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRot,
                rotateSpeed * Time.deltaTime
            );

            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}

