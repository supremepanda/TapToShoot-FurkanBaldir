using UnityEngine;

namespace UIControllers.UIPanelActivationBehaviour
{
    public abstract class UIPanelActivationBehaviour : MonoBehaviour
    {
        [SerializeField] protected GameObject panel;
        public abstract void ActivatePanel();
    }
}