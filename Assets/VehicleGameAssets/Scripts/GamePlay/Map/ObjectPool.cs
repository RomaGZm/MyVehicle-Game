using UnityEngine;
using System.Collections.Generic;

public class ObjectPool<T> where T : Component
{
    private readonly Queue<T> _objects = new Queue<T>();
    private readonly T _prefab;
    private readonly Transform _container;

    public ObjectPool(T prefab, int initialCount, Transform container = null)
    {
        _prefab = prefab;
        _container = container;

        for (int i = 0; i < initialCount; i++)
        {
            var obj = GameObject.Instantiate(_prefab, _container);
            obj.gameObject.SetActive(false);
            _objects.Enqueue(obj);
        }
    }

    public T Get()
    {
        var obj = _objects.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void Return(T obj)
    {
        obj.gameObject.SetActive(false);
        _objects.Enqueue(obj);
    }
}