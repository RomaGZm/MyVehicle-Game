using UnityEngine;
using VehicleGame.Gameplay.Enemy;

namespace VehicleGame.Gameplay.Player
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 60f;
        public float lifetime = 5f;
        public int damage = 5;
        private float timer;

        private void OnEnable()
        {
            timer = 0f;
        }

        //Bullet movement
        private void Update()
        {
            transform.position += transform.forward * speed * Time.deltaTime;

            timer += Time.deltaTime;
            if (timer >= lifetime)
                BulletPool.Instance.Return(gameObject);
        }
        //Trigger bullet collision to enemy
        private void OnTriggerEnter(Collider other)
        {
            int layer = other.gameObject.layer;

            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);

                BulletPool.Instance.Return(gameObject);
            }

        }
    }
}

