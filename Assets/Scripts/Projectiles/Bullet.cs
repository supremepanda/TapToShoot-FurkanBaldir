using ShootableSurfaces;
using UnityEngine;

namespace Projectiles
{
    public class Bullet : Projectile
    {
        [SerializeField] private float _hitForce;
    
        protected override void HitTarget(Collision target)
        {
            base.HitTarget(target);
            target.gameObject.GetComponent<ShootableSurface>().HitByProjectile();
            var targetRigidbody = target.gameObject.GetComponent<Rigidbody>();
            targetRigidbody.AddForce(Direction * _hitForce, ForceMode.Impulse);
        }
    }
}