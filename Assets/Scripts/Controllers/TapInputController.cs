using Managers;
using UnityEngine;

namespace Controllers
{
    public class TapInputController : MonoBehaviour
    {
        public delegate void SendInputPosition(Vector3 inputPosition);
        public delegate void ProjectileChangeInput();
        
        public event SendInputPosition OnTapAction;
        public event ProjectileChangeInput OnProjectileChangedInput;
        
        private void Update()
        {
            if (PlatformManager.Instance.platform == Platform.Editor)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    OnTapAction?.Invoke(Input.mousePosition);
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    OnProjectileChangedInput?.Invoke();
                }
            }
            else
            {
                if (Input.touchCount <= 0) return;
                Touch firstTouch = Input.GetTouch(0);
                if (Input.touchCount == 2)
                {
                    Touch secondTouch = Input.GetTouch(1);
                    if (firstTouch.phase == TouchPhase.Began && secondTouch.phase == TouchPhase.Began)
                    {
                        OnProjectileChangedInput?.Invoke();
                    }
                }
                else if(firstTouch.phase == TouchPhase.Began)
                {
                    OnTapAction?.Invoke(firstTouch.position);
                }
            }
        }
        
        
    }
}
