using UnityEngine;

namespace Controllers
{
    public class ProgressController : MonoBehaviour
    {
        public delegate void TargetHit();

        public event TargetHit OnHitTarget;
        
        private int _targetAmount;
        public int TargetAmount
        {
            set => _targetAmount = value;
        }

        private float percentageProgress = 0f;

        private void Start()
        {
            OnHitTarget += IncreaseProgress;
        }

        private void IncreaseProgress()
        {
            percentageProgress += 100 / _targetAmount;
            if (percentageProgress >= 100f)
            {
                Debug.Log("Gameover");
            }
        }

        public void InvokeOnHitTarget()
        {
            OnHitTarget?.Invoke();
        }
    }
}
