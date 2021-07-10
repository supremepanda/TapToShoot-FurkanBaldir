using System;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected Material material;
    protected Rigidbody rigidbody;
    
    protected abstract void HitTarget(Collision target);
    
    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
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
        rigidbody.velocity = transform.forward * speed;
    }
    
    
}