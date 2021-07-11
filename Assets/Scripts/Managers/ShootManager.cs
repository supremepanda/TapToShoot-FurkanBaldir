using UnityEngine;

namespace Managers
{
    public class ShootManager : MonoBehaviour
    {
        public bool isShootingEnabled;
        
        private void Awake()
        {
            isShootingEnabled = true;
        }
    }
}