using System.Collections;
using UnityEngine;

public class EnemyII : Enemy
{
    [SerializeField] private Projectile _projectilePrefab;
    private ProjectilePool _pool;
    [SerializeField] private float _delay;

    private void Start()
    {
        _pool = new(_projectilePrefab);
    }

    private void OnEnable()
    {
        IsCanAttack = true;
    }

    protected override void PlayAttack()
    {
        IsCanAttack = false;
        base.PlayAttack();
    }

    protected override void ExecuteAttack()
    {
        Projectile projectile = _pool.Spawn();
        projectile.transform.position = transform.position;
        projectile.Shoot(_pool);

        base.ExecuteAttack();
    }

    protected override void CompleteAttack()
    {
        StartCoroutine(Reload());

        base.CompleteAttack();
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(_delay);
        IsCanAttack = true;
        Attack();
    }
}
