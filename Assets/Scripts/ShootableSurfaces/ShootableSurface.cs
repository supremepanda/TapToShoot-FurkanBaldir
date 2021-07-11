using System.Collections;
using Controllers;
using UnityEngine;

namespace ShootableSurfaces
{
    public abstract class ShootableSurface : MonoBehaviour
    {
        protected abstract void ChangeColorRandom();
        
        private const float DestroyTime = 3f;
        
        public bool isHit;
        protected Material SurfaceMaterial;

        public delegate void Hit();
        public static event Hit OnHit;
        
        protected virtual void Awake()
        {
            isHit = false;
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