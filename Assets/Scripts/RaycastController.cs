using UnityEngine;

public class RaycastController : MonoBehaviour
{
    public delegate void RaycastTarget();
    public event RaycastTarget OnTargetRaycasted;
    
    private InputController _inputController;
    private Camera _mainCamera;
    private void Start()
    {
        _inputController = FindObjectOfType<InputController>();
        _mainCamera = Camera.main;
        
        _inputController.OnTapAction += SendRayCast;
        
    }

    private void SendRayCast(Vector3 inputPosition)
    {
        RaycastHit hit;
        Ray ray = _mainCamera.ScreenPointToRay(inputPosition);
        if (!Physics.Raycast(ray, out hit, Mathf.Infinity)) return;
        if (hit.collider.CompareTag("Target"))
        {
            Debug.Log("target");
            OnTargetRaycasted?.Invoke();
        }
    }
}