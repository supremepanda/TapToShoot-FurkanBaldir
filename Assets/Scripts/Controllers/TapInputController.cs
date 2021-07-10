using Managers;
using UnityEngine;

namespace Controllers
{
    public class TapInputController : MonoBehaviour
    {
        public delegate void SendInputPosition(Vector3 inputPosition);
        public event SendInputPosition OnTapAction;
        
        private Platform _platform;
        private void Start()
        {
            _platform = PlatformManager.Instance.platform;
        }

        private void Update()
        {
            if (_platform == Platform.Editor)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    OnTapAction?.Invoke(Input.mousePosition);
                }
            }
            else
            {
                if (Input.touchCount <= 0) return;
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    OnTapAction?.Invoke(touch.position);
                }
            }
        }
    }
}
