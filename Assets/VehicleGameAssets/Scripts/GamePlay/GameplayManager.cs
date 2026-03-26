using UnityEngine;
using VehicleGame.Gameplay.Map;
using VehicleGame.Gameplay.Player;

namespace VehicleGame.Gameplay
{
    public class GameplayManager : MonoBehaviour
    {
        public BaseCarController carController;
        public RoadSpawner roadSpawner;
        public Transform carSpawnPoint;
        [SerializeField] private GameObject carPrefab;
        public bool isPause { get; private set; }

        public static GameplayManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

            }
        }
        private void Start()
        {
            roadSpawner.Init();
            //SpawnCar();
        }

        public void Win()
        {
            isPause = true;
        }

        public void SetPause(bool pause)
        {
            isPause = pause;
        }
        private void SpawnCar()
        {
            carController = Instantiate(carPrefab, carSpawnPoint.position, carSpawnPoint.rotation).GetComponent<BaseCarController>();
        }
    }
}
