using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance;
    
    public Platform platform;
    
    private void Awake()
    {
        if (Instance != null) return;
        Instance = this;
        InitializePlatformManager();
    }

    private void InitializePlatformManager()
    {
#if UNITY_EDITOR
        platform = Platform.Editor;
#else
        platform = Platfor.Mobile;
#endif
    }
}
