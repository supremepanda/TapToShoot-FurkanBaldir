using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class PlatformManager : MonoBehaviour
    {
        public static PlatformManager Instance;
    
        public Platform platform;
    
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            Instance = this;
            InitializePlatformManager();
        }

        private void InitializePlatformManager()
        {
#if UNITY_EDITOR
            Instance.platform = Platform.Editor;
#else
            Instance.platform = Platfor.Mobile;
#endif
        }
    }
}
