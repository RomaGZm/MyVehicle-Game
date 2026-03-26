using System.Collections.Generic;
using UnityEngine;
using VehicleGame.Gameplay.Enemy;

namespace VehicleGame.Gameplay.Map
{
    public class EnemiesSpawner : MonoBehaviour
    {
        [Header("Pool")]
        [SerializeField] private EnemiesDatabase enemiesDatabase;
        public int enemyPoolSize = 10;

        [Space]
        public List<BaseEnemy> enemies;
        [Header("Detection Area")]
        [SerializeField] private BoxCollider boxCollider;

        public void Init()
        {
            CreateEnemies();
        }
        private void OnEnable()
        {
            EnableEnemies(true);
        }
        private void OnDisable()
        {
            EnableEnemies(false);
        }
        /// <summary>
        /// Enable or Disable all enemies
        /// </summary>
        /// <param name="en"></param>
        public void EnableEnemies(bool en)
        {
            foreach (BaseEnemy enemy in enemies)
            {
                enemy.gameObject.SetActive(en);
            }
        }
        /// <summary>
        /// Instantiate enemies
        /// </summary>
        public void CreateEnemies()
        {
            enemies = new List<BaseEnemy>(enemyPoolSize);

            for (int i = 0; i < enemyPoolSize; i++)
            {
                BaseEnemy enemy = Instantiate(enemiesDatabase.GetRandomEnemyData().enemy, transform);
                enemies.Add(enemy);
            }
            ChangePositions();
        }
        /// <summary>
        /// Change all enemies random position
        /// </summary>
        [ContextMenu("ChangePositions")]
        public void ChangePositions()
        {
            foreach (BaseEnemy enemy in enemies)
            {
                Vector3 p = GetRandomPoint();
                enemy.transform.position = p;
            }
        }
        //Return random point in area
        private Vector3 GetRandomPoint()
        {
            Vector3 center = boxCollider.transform.TransformPoint(boxCollider.center);

            Vector3 extents = boxCollider.size * 0.5f;

            Vector3 worldExtents = boxCollider.transform.lossyScale;
            worldExtents = Vector3.Scale(worldExtents, extents);

            float x = Random.Range(-worldExtents.x, worldExtents.x);
            float z = Random.Range(-worldExtents.z, worldExtents.z);

            float y = center.y;

            return new Vector3(center.x + x, y, center.z + z);
        }
    }

}
