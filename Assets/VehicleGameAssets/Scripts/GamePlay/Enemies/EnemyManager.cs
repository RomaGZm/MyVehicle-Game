
using UnityEngine;
using VehicleGame.Gameplay.Map;
using VehicleGame.Gameplay.Player;

namespace VehicleGame.Gameplay.Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemiesSpawner enemiesSpawner;

        private BaseCarController player;
        private float updateRate = 0.1f;
        private float timer;

        public void Init()
        {
            player = GameplayManager.Instance.carController;
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= updateRate)
            {
                timer = 0;
                UpdateDistances();
            }
        }

        //Optimization detect distance
        private void UpdateDistances()
        {
            Vector3 pPos = player.transform.position;

            foreach (var enemy in enemiesSpawner.enemies)
            {
                enemy?.enemyAI?.UpdateDistance(pPos);
            }
        }
    }
}
