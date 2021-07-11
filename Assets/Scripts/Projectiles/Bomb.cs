using ShootableSurfaces;
using UnityEngine;

namespace Projectiles
{
    public class Bomb : Projectile
    {
        [SerializeField] private float explosionForce;
        [SerializeField] private float radius;
    
        protected override void HitTarget(Collision target)
        {
            base.HitTarget(target);
            Collider[] colliders = Physics.OverlapSphere(target.GetContact(0).point, radius);
            foreach (var nearBy in colliders)
            {
                if (!nearBy.CompareTag("Target")) continue;
                Rigidbody rb = nearBy.GetComponent<Rigidbody>();
                if (rb == null) continue;
                rb.gameObject.GetComponent<ShootableSurface>().HitByProjectile();
                rb.AddExplosionForce(explosionForce, transform.position, radius);
            }
        }
    }
}