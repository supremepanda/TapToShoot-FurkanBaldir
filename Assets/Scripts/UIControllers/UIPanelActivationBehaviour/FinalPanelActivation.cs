using Controllers;

namespace UIControllers.UIPanelActivationBehaviour
{
    public class FinalPanelActivation : UIPanelActivationBehaviour
    {
        private ProgressController _progressController;
        
        private void OnDestroy()
        {
            _progressController.OnFinishedProgress -= ActivatePanel;
        }

        private void Start()
        {
            _progressController = FindObjectOfType<ProgressController>();
            _progressController.OnFinishedProgress += ActivatePanel;
        }

        public override void ActivatePanel()
        {
            Panel.SetActive(true);
        }
    }
}