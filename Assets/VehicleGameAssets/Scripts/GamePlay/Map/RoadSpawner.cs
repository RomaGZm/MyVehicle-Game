using UnityEngine;
using System.Collections.Generic;

public class RoadSpawner : MonoBehaviour
{
    [Header("Settings")]
    public RoadPiece roadPrefab;
    public int poolSize = 10;
    public int initialActive = 3;

    private ObjectPool<RoadPiece> _pool;
    private readonly List<RoadPiece> _activeSegments = new List<RoadPiece>();

    private float _currentEndZ = 0f;

    private void Start()
    {
        _pool = new ObjectPool<RoadPiece>(roadPrefab, poolSize, transform);

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

        _currentEndZ += piece.Length;

        piece.OnPlayerEntered = HandlePlayerEntered;
        _activeSegments.Add(piece);
    }

    private void HandlePlayerEntered(RoadPiece piece)
    {
        if (_activeSegments.Count < 2 || piece != _activeSegments[1])
            return;

        // remove first segment
        var first = _activeSegments[0];
        _activeSegments.RemoveAt(0);

        // return it to pool
        _pool.Return(first);

        // spawn new at end
        SpawnNextPiece();
    }
}