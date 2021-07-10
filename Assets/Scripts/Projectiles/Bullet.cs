using UnityEngine;

namespace Projectiles
{
    public class Bullet : Projectile
    {
        [SerializeField] private float hitForce;
    
        protected override void HitTarget(Collision target)
        {
            var forceDirection = -target.GetContact(0).normal;   
            var targetRigidbody = target.gameObject.GetComponent<Rigidbody>();
        
            targetRigidbody.AddForce(forceDirection * hitForce, ForceMode.Impulse);
        }
    }
}