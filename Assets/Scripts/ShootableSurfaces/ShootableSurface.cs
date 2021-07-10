using UnityEngine;

namespace ShootableSurfaces
{
    public abstract class ShootableSurface : MonoBehaviour
    {
        public bool isHit;
        
        protected Material SurfaceMaterial;
        protected Rigidbody SurfaceRigidbody;
        
        protected abstract void ChangeColorRandom();
    
        protected virtual void Awake()
        {
            SurfaceRigidbody = GetComponent<Rigidbody>();
            isHit = false;
        }
    }
}