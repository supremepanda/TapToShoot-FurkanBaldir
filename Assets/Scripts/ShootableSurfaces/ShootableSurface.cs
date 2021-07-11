using System;
using System.Collections;
using Controllers;
using UnityEngine;

namespace ShootableSurfaces
{
    public abstract class ShootableSurface : MonoBehaviour
    {
        public delegate void Hit();
        public static event Hit OnHit;

        private const float DestroyTime = 3f;
        
        public bool isHit;
        
        protected Material SurfaceMaterial;
        protected Rigidbody SurfaceRigidbody;
        private Collider _collider;
        private ProgressController _progressController;

        protected abstract void ChangeColorRandom();
    
        protected virtual void Awake()
        {
            SurfaceRigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            isHit = false;
        }

        protected void Start()
        {
            _progressController = FindObjectOfType<ProgressController>();
        }

        public void HitByProjectile()
        {
            if (isHit) return;
            isHit = true;
            OnHit?.Invoke();
            StartCoroutine(DestroyInTime(DestroyTime));
        }

        private IEnumerator DestroyInTime(float time)
        {
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
        }
    }
}