using UnityEngine;

namespace Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] protected float speed;
        private Rigidbody _rigidbody;
    
        protected abstract void HitTarget(Collision target);
    
        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Target"))
            {
                HitTarget(other);
            }
        }

        public void Fire(Transform targetTransform)
        {
            Transform transform1;
            (transform1 = transform).LookAt(targetTransform);
            _rigidbody.velocity = transform1.forward * speed;
        }
    
    
    }
}