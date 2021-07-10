using UnityEngine;

public class InputController : MonoBehaviour
{
    public delegate void SendInputPosition(Vector3 inputPosition);
    public event SendInputPosition OnTapAction;
    
    private void Update()
    {
#if UNITY_EDITOR
        if (!Input.GetMouseButtonDown(0)) return;
        OnTapAction?.Invoke(Input.mousePosition);
#elif UNITY_ANDROID
        if (Input.touchCount <= 0) return;
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            OnTapAction?.Invoke(touch.position);
        }
#endif
    }
}
