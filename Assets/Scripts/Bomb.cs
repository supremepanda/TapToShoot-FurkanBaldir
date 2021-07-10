using UnityEngine;

public class Bomb : Projectile
{
    [SerializeField] private float explosionRange;
    
    protected override void HitTarget(Collision target)
    {
        Debug.Log(target.gameObject.name);
    }
}