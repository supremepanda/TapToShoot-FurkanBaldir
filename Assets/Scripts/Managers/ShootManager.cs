using UnityEngine;

namespace Managers
{
    public class ShootManager : MonoBehaviour
    {
        public static ShootManager Instance;
        public bool isShootingEnabled;
    
        private void Awake()
        {
            if (Instance != null) return;
            Instance = this;
            InitializeShootManager();
            Application.targetFrameRate = 60;
        }

        private void InitializeShootManager()
        {
            isShootingEnabled = true;
        }
    }
}