using System;
using Managers;
using ShootableSurfaces;
using UnityEngine;

namespace Controllers
{
    public class RaycastController : MonoBehaviour
    {
        public delegate void RaycastTarget(Transform targetTransform);
        public event RaycastTarget OnTargetRaycasted;
    
        private TapInputController _tapInputController;
        private ShootManager _shootManager;
        private Camera _mainCamera;
        private void Start()
        {
            _tapInputController = FindObjectOfType<TapInputController>();
            _shootManager = FindObjectOfType<ShootManager>();
            _mainCamera = Camera.main;
        
            _tapInputController.OnTapAction += SendRayCast;
        }

        private void OnDestroy()
        {
            _tapInputController.OnTapAction -= SendRayCast;
        }

        private void SendRayCast(Vector3 inputPosition)
        {
            if (!_shootManager.isShootingEnabled) return;
            RaycastHit hit;
            Ray ray = _mainCamera.ScreenPointToRay(inputPosition);
            if (!Physics.Raycast(ray, out hit, Mathf.Infinity)) return;
            if (!hit.collider.CompareTag("Target")) return;
            if (hit.collider.gameObject.GetComponent<ShootableSurface>().isHit) return;
            var targetDirection = ray.direction;
            OnTargetRaycasted?.Invoke(hit.transform);

        }
    }
}