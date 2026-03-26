using UnityEngine;
using System.Collections.Generic;

namespace VehicleGame.Gameplay.Player
{
    public class BulletPool : MonoBehaviour
    {
        public static BulletPool Instance;

        public GameObject bulletPrefab;
        public int size = 20;

        private Queue<GameObject> pool = new();

        private void Awake()
        {
            Instance = this;

            for (int i = 0; i < size; i++)
            {
                var b = Instantiate(bulletPrefab);
                b.SetActive(false);
                pool.Enqueue(b);
            }
        }

        public GameObject Get()
        {
            if (pool.Count == 0)
            {
                var b = Instantiate(bulletPrefab);
                b.SetActive(false);
                return b;
            }

            return pool.Dequeue();
        }

        public void Return(GameObject bullet)
        {
            bullet.SetActive(false);
            pool.Enqueue(bullet);
        }
    }
}
