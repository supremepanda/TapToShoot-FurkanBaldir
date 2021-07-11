using System;
using ShootableSurfaces;
using UIControllers;
using UIControllers.UIText;
using UnityEngine;

namespace Controllers
{
    public class ProgressController : MonoBehaviour
    {
        public delegate void IncreaseProgressPercentage(float percentage);
        public event IncreaseProgressPercentage OnIncreasedProgress;

        public delegate void FinishProgress();
        public event FinishProgress OnFinishedProgress;
        
        private int _targetAmount;
        public int TargetAmount
        {
            set => _targetAmount = value;
        }

        private UITextBehaviour _uiProgress;
        private float _percentageProgress = 0f;

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
            Debug.Log(_percentageProgress);
            _percentageProgress += 100 / _targetAmount;
            OnIncreasedProgress?.Invoke(_percentageProgress);
            if (!(_percentageProgress >= 100f)) return;
            Debug.Log("gameover");
            OnFinishedProgress?.Invoke();
        }
    }
}
