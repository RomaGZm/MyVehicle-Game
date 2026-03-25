using UnityEngine;

public class RoadPiece : MonoBehaviour
{
    [Header("Road")]
    [SerializeField] private MeshRenderer roadMesh;

    public float roadLength = 20;

    [Header("Enemy")]
    [SerializeField] private EnemiesSpawner enemiesSpawner;

    public void SetActive()
    {
        gameObject.SetActive(true);
    }

    [ContextMenu("CalculateLength")]
    private void CalculateLength()
    {
        roadLength = roadMesh.bounds.size.z;
    }

    public System.Action<RoadPiece> OnPlayerEntered;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            OnPlayerEntered?.Invoke(this);
    }
}