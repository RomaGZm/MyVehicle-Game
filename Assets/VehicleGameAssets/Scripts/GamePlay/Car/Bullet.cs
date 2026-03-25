using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 60f;
    public float lifetime = 2f;

    private float timer;

    private void OnEnable()
    {
        timer = 0f;
    }

    private void Update()
    {
        // Move forward manually (no physics)
        transform.position += transform.forward * speed * Time.deltaTime;

        timer += Time.deltaTime;
        if (timer >= lifetime)
            BulletPool.Instance.Return(gameObject);
    }
}