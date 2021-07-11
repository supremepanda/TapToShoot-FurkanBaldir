using ShootableSurfaces;
using UIControllers.UIText;
using UnityEngine;

namespace Controllers
{
    public class ProgressController : MonoBehaviour
    {
        private int _targetAmount;
        private UITextBehaviour _uiProgress;
        private double _percentageProgress = 0d;
        
        private void OnDestroy()
        {
            ShootableSurface.OnHit -= IncreaseProgress;
        }
        
        public delegate void IncreaseProgressPercentage(double percentage);
        public delegate void FinishProgress();
        
        public event IncreaseProgressPercentage OnIncreasedProgress;
        public event FinishProgress OnFinishedProgress;
        
        private void Start()
        {
            _uiProgress = FindObjectOfType<UITextBehaviour>();
            _uiProgress.UpdateEditableText(_percentageProgress);
            OnIncreasedProgress?.Invoke(_percentageProgress);
            ShootableSurface.OnHit += IncreaseProgress;
        }
        
        public int TargetAmount
        {
            set => _targetAmount = value;
        }
        
        private void IncreaseProgress()
        {
            _percentageProgress += 100d / _targetAmount;
            OnIncreasedProgress?.Invoke((int)Mathf.Floor((float)_percentageProgress));
            if (!(_percentageProgress >= 100d)) return;
            OnFinishedProgress?.Invoke();
        }
    }
}
