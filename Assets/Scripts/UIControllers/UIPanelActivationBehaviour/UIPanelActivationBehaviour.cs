using UnityEngine;

namespace UIControllers.UIPanelActivationBehaviour
{
    public abstract class UIPanelActivationBehaviour : MonoBehaviour
    {
        public abstract void ActivatePanel();
        
        [SerializeField] protected GameObject Panel;
        
    }
}