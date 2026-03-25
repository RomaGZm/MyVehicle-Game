using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesDatabase", menuName = "GameDatas/EnemiesDatabase")]
public class EnemiesDatabase : ScriptableObject
{
    [System.Serializable]
    public class EnemyData
    {
        public string enemyName;
        public BaseEnemy enemy;
    }
    public List<EnemyData> enemyDatas;
   
    public EnemyData GetEnemyData(int index)
    {
        return enemyDatas[index];
    }
    public EnemyData GetRandomEnemyData()
    {
        return GetEnemyData(Random.Range(0, enemyDatas.Count)); 
    }
    public List<BaseEnemy> GetEnemies()
    {
        List<BaseEnemy> enemies = new List<BaseEnemy>();
        
        foreach (EnemyData enemyData in enemyDatas)
            enemies.Add(enemyData.enemy);

        return enemies;
    }
}
