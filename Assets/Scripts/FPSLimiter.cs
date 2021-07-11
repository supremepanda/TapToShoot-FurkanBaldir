using System;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    [SerializeField] private FPSMode fpsMode;

    private void Start()
    {
#if UNITY_EDITOR
        Application.targetFrameRate = (int) fpsMode;
#endif
    }
}
