using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T>
    where T : Object
{
    private Queue<T> _storage = new();

    public ObjectPool(T prototype)
    {
        Prototype = prototype;
    }

    public T Prototype { get; }

    public T Spawn()
    {
        if(_storage.Count > 0)
        {
            OnSpawn(_storage.Peek());
            return _storage.Dequeue();
        }
        else
        {
            return Create();
        }
    }

    public void Despawn(T @object)
    {
        OnDespawn(@object);
        _storage.Enqueue(@object);
    }

    protected virtual T Create()
    {
        T @object = GameObject.Instantiate(Prototype);
        @object.name = Prototype.name;

        return @object;
    }
    protected virtual void OnSpawn(T @object) { }
    protected virtual void OnDespawn(T @object) { }
}
