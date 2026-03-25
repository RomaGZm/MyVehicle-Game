using System.Collections.Generic;
using UnityEngine;


public class EnemiesSpawner : MonoBehaviour
{
    [Header("Enemies")]
    [SerializeField] private EnemiesDatabase enemiesDatabase;
    public int enemyPoolSize = 10;

    private List<BaseEnemy> enemies;

    [SerializeField] private BoxCollider boxCollider;

    private void Awake()
    {
        CreateEnemies();
    }

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
    [ContextMenu("ChangePositions")]
    public void ChangePositions()
    {
        foreach (BaseEnemy enemy in enemies)
        {
            Vector3 p = GetRandomPoint();
            enemy.transform.position = p;
        }
    }
    
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
