using UnityEngine;

public class EnemyService
{
    private static EnemyService _instane;
    private readonly EnemyPool Pool;

    private EnemyService()
    {
        Pool = new();
    }

    public void ShowEnemy(Enemy prefab, Vector3 position)
    {
        if(CurrentEnemy != null)
        {
            Pool.Despawn(CurrentEnemy);
        }

        CurrentEnemy = Pool.Spawn(prefab);
        CurrentEnemy.transform.position = position;
    }

    public static EnemyService Instance
    {
        get
        {
            if (_instane == null)
            {
                _instane = new();
            }

            return _instane;
        }
    }

    public Enemy CurrentEnemy { get; private set; }
}
