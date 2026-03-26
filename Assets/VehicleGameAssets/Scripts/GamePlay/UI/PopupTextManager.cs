using UnityEngine;
using System.Collections.Generic;

namespace VehicleGame.Gameplay.UI
{
    public class PopupTextManager : MonoBehaviour
    {
        public static PopupTextManager Instance;

        [Header("Settings")]
        public PopupText popupPrefab;
        public int poolSize = 20;

        private readonly Queue<PopupText> pool = new Queue<PopupText>();

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);

            CreatePool();
        }

        public void Show(string text, Transform target, float speed,
                               Vector2 direction, Color color, int size)
        {
            var obj = Get();
            obj.Play(text, target, speed, direction, color, size);
        }
        private void CreatePool()
        {
            for (int i = 0; i < poolSize; i++)
            {
                PopupText obj = Instantiate(popupPrefab, transform);
                obj.gameObject.SetActive(false);
                pool.Enqueue(obj);
            }
        }

        public PopupText Get()
        {
            if (pool.Count == 0)
                CreatePool();

            PopupText obj = pool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }

        public void ReturnToPool(PopupText obj)
        {
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }
}

