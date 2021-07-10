using System;
using UnityEngine;

public abstract class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected Material material;
    protected Rigidbody rigidbody;
    
    protected abstract void HitTarget(GameObject target);
    
    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    protected void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            HitTarget(other.gameObject);
        }
    }

    public void Fire(Vector3 direction)
    {
        rigidbody.velocity = direction * speed;
    }
    
    
}