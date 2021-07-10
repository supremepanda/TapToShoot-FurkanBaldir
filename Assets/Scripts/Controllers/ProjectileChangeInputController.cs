using Managers;
using UnityEngine;

namespace Controllers
{
    public class ProjectileChangeInputController : MonoBehaviour
    {
        public delegate void ProjectileChangeInput();
        public event ProjectileChangeInput OnProjectileChangedInput;

        private Platform _platform;
        private void Start()
        {
            _platform = PlatformManager.Instance.platform;
        }
        
        private void Update()
        {
            if (_platform == Platform.Editor)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    OnProjectileChangedInput?.Invoke();
                }
            }
            else
            {
                if (Input.touchCount == 2)
                {
                    OnProjectileChangedInput?.Invoke();
                }
            }
            
        }
    }
}