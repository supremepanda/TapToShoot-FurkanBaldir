using System.Collections;
using UnityEngine;

namespace Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        private const float DestroyTime = 6f;
        private const float HitDestroyTime = 2f;
        
        [SerializeField] protected float speed;
        protected Vector3 Direction;
        private Rigidbody _rigidbody;

        protected virtual void HitTarget(Collision target)
        {
            StartCoroutine(DestroyInTime(HitDestroyTime));
        }
        
        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void Start()
        {
            StartCoroutine(DestroyInTime(DestroyTime));
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
            transform.LookAt(targetTransform);
            Direction = transform.forward;
            _rigidbody.velocity = Direction * speed;
        }

        protected IEnumerator DestroyInTime(float time)
        {
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
        }
    }
}