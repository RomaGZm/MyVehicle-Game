using UnityEngine;
using VehicleGame.Gameplay.Enemy;

namespace VehicleGame.Gameplay.Map
{
    public class RoadPiece : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private MeshRenderer roadMesh;
        public System.Action<RoadPiece> OnPlayerEntered;

        [Header("Controllers")]
        public EnemiesSpawner enemiesSpawner;
        public EnemyManager enemyManager;
        [Space(10)]
        public float roadLength = 20;

        public void Init()
        {
            enemiesSpawner.Init();
            enemyManager.Init();
        }

        public void SetActive()
        {
            gameObject.SetActive(true);
        }

        [ContextMenu("CalculateLength")]
        private void CalculateLength()
        {
            roadLength = roadMesh.bounds.size.z;
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                OnPlayerEntered?.Invoke(this);
        }
    }
}

