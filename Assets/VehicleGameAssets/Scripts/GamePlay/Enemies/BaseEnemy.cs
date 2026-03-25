using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public StickmanAnimations enemyAnimations;

    public virtual void Active()
    {
        enemyAnimations.RandomIdle();

    }
}
