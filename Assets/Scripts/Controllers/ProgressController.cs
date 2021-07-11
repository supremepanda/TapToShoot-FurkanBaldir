using System;
using ShootableSurfaces;
using UIControllers;
using UIControllers.UIText;
using UnityEngine;

namespace Controllers
{
    public class ProgressController : MonoBehaviour
    {
        public delegate void IncreaseProgressPercentage(double percentage);
        public event IncreaseProgressPercentage OnIncreasedProgress;

        public delegate void FinishProgress();
        public event FinishProgress OnFinishedProgress;
        
        private int _targetAmount;
        public int TargetAmount
        {
            set => _targetAmount = value;
        }

        private UITextBehaviour _uiProgress;
        private double _percentageProgress = 0d;

        private void Start()
        {
            _uiProgress = FindObjectOfType<UITextBehaviour>();
            _uiProgress.UpdateEditableText(_percentageProgress);
            OnIncreasedProgress?.Invoke(_percentageProgress);
            ShootableSurface.OnHit += IncreaseProgress;
        }
        
        private void OnDestroy()
        {
            ShootableSurface.OnHit -= IncreaseProgress;
        }
        
        private void IncreaseProgress()
        {
            _percentageProgress += 100d / _targetAmount;
            Debug.Log(_percentageProgress);
            OnIncreasedProgress?.Invoke((int)Mathf.Floor((float)_percentageProgress));
            if (!(_percentageProgress >= 100d)) return;
            OnFinishedProgress?.Invoke();
        }
    }
}
