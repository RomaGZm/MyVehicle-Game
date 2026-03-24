using UnityEngine;

public class RoadPiece : MonoBehaviour
{
    [SerializeField] private MeshRenderer roadMesh;
    public float Length = 20;

    [ContextMenu("CalculateLength")]
    private void CalculateLength()
    {
        Length = roadMesh.bounds.size.z;
    }

    public System.Action<RoadPiece> OnPlayerEntered;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            OnPlayerEntered?.Invoke(this);
    }
}