using ShootableSurfaces;
using UnityEngine;

namespace Projectiles
{
    public class Bullet : Projectile
    {
        [SerializeField] private float hitForce;
    
        protected override void HitTarget(Collision target)
        {
            target.collider.gameObject.GetComponent<ShootableSurface>().isHit = true;
            var forceDirection = -target.GetContact(0).normal;   
            var targetRigidbody = target.gameObject.GetComponent<Rigidbody>();
            targetRigidbody.AddForce(forceDirection * hitForce, ForceMode.Impulse);
            
            Destroy(gameObject);
        }
    }
}