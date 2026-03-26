using UnityEngine;

namespace VehicleGame.Gameplay.Enemy
{
    public class BaseEnemy : MonoBehaviour
    {
        public EnemyAI enemyAI;
        public EnemyHealth enemyHealth;
        public EnemyAnimation enemyAnimations;

        public virtual void Init()
        {
            enemyAnimations.RandomIdle();

        }
    }
}

