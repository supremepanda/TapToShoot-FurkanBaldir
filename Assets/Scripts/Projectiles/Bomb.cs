using UnityEngine;

namespace Projectiles
{
    public class Bomb : Projectile
    {
        [SerializeField] private float explosionForce;
        [SerializeField] private float radius;
    
        protected override void HitTarget(Collision target)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach (var nearBy in colliders)
            {
                Rigidbody rb = nearBy.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, radius);
                }
            }
        }
    }
}