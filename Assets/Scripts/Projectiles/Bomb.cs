using ShootableSurfaces;
using UnityEngine;

namespace Projectiles
{
    public class Bomb : Projectile
    {
        [SerializeField] private float _explosionForce;
        [SerializeField] private float _radius;
    
        protected override void HitTarget(Collision target)
        {
            Collider[] colliders = Physics.OverlapSphere(target.GetContact(0).point, _radius);
            foreach (var nearBy in colliders)
            {
                if (!nearBy.CompareTag("Target")) continue;
                Rigidbody rb = nearBy.GetComponent<Rigidbody>();
                if (rb == null) continue;
                rb.gameObject.GetComponent<ShootableSurface>().HitByProjectile();
                rb.AddExplosionForce(_explosionForce, transform.position, _radius);
            }

            StartCoroutine(DestroyInTime(0f));
        }
    }
}