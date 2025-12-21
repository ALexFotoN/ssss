using UnityEngine;

public class ProjectilePool : ObjectPool<Projectile>
{
    public ProjectilePool(Projectile prototype) : base(prototype)
    {
    }

    protected override void OnSpawn(Projectile @object)
    {
        @object.gameObject.SetActive(true);
    }

    protected override void OnDespawn(Projectile @object)
    {
        @object.gameObject.SetActive(false);
    }
}
