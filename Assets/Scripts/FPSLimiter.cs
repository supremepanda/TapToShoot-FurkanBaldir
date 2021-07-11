using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    [SerializeField] private FPSMode _fpsMode;

    private void Start()
    {
#if UNITY_EDITOR
        Application.targetFrameRate = (int) _fpsMode;
#endif
    }
}
