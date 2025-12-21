using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;

    public ProjectilePool Pool { get; private set; }

    private void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
    public void Shoot(ProjectilePool pool)
    {
        Pool = pool;
        StartCoroutine(Lifetime());
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(2);
        Pool.Despawn(this);
    }
}
