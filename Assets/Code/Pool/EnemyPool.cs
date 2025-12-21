using System.Collections.Generic;
using UnityEngine;

public class EnemyPool 
{
    private Dictionary<string, Pool> _pools = new();

    public Enemy Spawn(Enemy prefab)
    {
        if(!_pools.TryGetValue(prefab.name, out var pool))
        {
            pool = new(prefab);
            _pools.Add(prefab.name, pool);
        }

        return pool.Spawn();
    }

    public void Despawn(Enemy @object)
    {
        if(_pools.TryGetValue(@object.name, out var pool))
        {
            pool.Despawn(@object);
        }
        else
        {
            GameObject.Destroy(@object.gameObject);
        }
    }

    private class Pool : ObjectPool<Enemy>
    {
        public Pool(Enemy prototype) : base(prototype)
        {
        }

        protected override void OnSpawn(Enemy @object)
        {
            @object.gameObject.SetActive(true);
        }

        protected override void OnDespawn(Enemy @object)
        {
            @object.gameObject.SetActive(false);
        }
    }
}
