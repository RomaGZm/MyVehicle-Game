using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VehicleGame.Gameplay.Map
{
    public class RoadSpawner : MonoBehaviour
    {
        [Header("Settings")]
        public RoadPiece roadPrefab;
        public int poolSize = 10;
        public int initialActive = 3;
        public float delayReturRoadPieces = 4;

        private ObjectPool<RoadPiece> _pool;
        private readonly List<RoadPiece> _activeSegments = new List<RoadPiece>();
        private RoadPiece firstRoadPiece;
        private float _currentEndZ = 0f;

        //Create road piese pool
        public void Init()
        {
            _pool = new ObjectPool<RoadPiece>(roadPrefab, poolSize, transform);

            foreach (var rp in _pool.objects)
            {
                rp.Init();
            }
            // spawn initial pieces
            for (int i = 0; i < initialActive; i++)
            {
                SpawnNextPiece();
            }
        }
        
        [ContextMenu("SpawnNextPiece")]
        private void SpawnNextPiece()
        {

            var piece = _pool.Get();
            piece.transform.position = new Vector3(0, 0, _currentEndZ);

            _currentEndZ += piece.roadLength;

            piece.OnPlayerEntered = HandlePlayerEntered;
            _activeSegments.Add(piece);

        }
        //Car trriger
        private void HandlePlayerEntered(RoadPiece piece)
        {
            if (_activeSegments.Count < 2 || piece != _activeSegments[1])
                return;

            // remove first segment
            firstRoadPiece = _activeSegments[0];
            _activeSegments.RemoveAt(0);

            StartCoroutine(RoadPieceReturn(delayReturRoadPieces));
            SpawnNextPiece();

        }
        //Return piece in pool
        IEnumerator RoadPieceReturn(float delay)
        {
            yield return new WaitForSeconds(delay);
            _pool.Return(firstRoadPiece);
        }
    }
}
