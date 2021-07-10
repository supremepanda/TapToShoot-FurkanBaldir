using System;
using System.Collections;
using UnityEngine;

namespace ShootableSurfaces
{
    public abstract class ShootableSurface : MonoBehaviour
    {
        private const float DestroyTime = 3f;
        
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

        public void HitByProjectile()
        {
            isHit = true;
            StartCoroutine(DestroyInTime(DestroyTime));
        }

        private IEnumerator DestroyInTime(float time)
        {
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
        }
    }
}