using System;
using UnityEngine;

namespace ShootableSurfaces
{
    public abstract class ShootableSurface : MonoBehaviour
    {
        public bool isHit;
        
        protected Material SurfaceMaterial;
        protected Rigidbody SurfaceRigidbody;
        private Collider _collider;
        
        protected abstract void ChangeColorRandom();
    
        protected virtual void Awake()
        {
            SurfaceRigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            isHit = false;
        }

        protected void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Target"))
            {
                Physics.IgnoreCollision(other.collider, _collider);
            }
        }
    }
}