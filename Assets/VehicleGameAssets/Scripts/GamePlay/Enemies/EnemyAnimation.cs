using UnityEngine;

namespace VehicleGame.Gameplay.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public const string Idle_Anim = "Idle";
        public static readonly int IdleHash = Animator.StringToHash(Idle_Anim);

        public const string Hit_Anim = "Hit";
        public static readonly int HitHash = Animator.StringToHash(Hit_Anim);

        public const string Move_Anim = "Move";
        public static readonly int MoveHash = Animator.StringToHash(Move_Anim);

        public const string Run_Anim = "Run";
        public static readonly int RunHash = Animator.StringToHash(Run_Anim);

        public const string Attack_Anim = "Attack";
        public static readonly int AttackHash = Animator.StringToHash(Attack_Anim);

        [Header("Settings")]
        [SerializeField] private int maxIdleAnim = 3;

        public void Idle(int index)
        {
            animator.SetInteger(IdleHash, index);
        }
        public void RandomIdle()
        {
            Idle(Random.Range(0, maxIdleAnim + 1));
        }

        public void Hit()
        {
            animator.SetTrigger(HitHash);
        }
        public void Move(bool value)
        {
            animator.SetBool(MoveHash, value);
        }
        public void Run(bool value)
        {
            Idle(0);
            animator.SetBool(Run_Anim, value);
        }
        public void Attack()
        {
            animator.SetTrigger(AttackHash);
        }
    }

}
