using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public bool isShootingActive;
    public Platform platform;
    
    private void Awake()
    {
        if (Instance != null) return;
        Instance = this;
        InitializeGameManager();
    }

    private void InitializeGameManager()
    {
        isShootingActive = true;

#if UNITY_EDITOR
        platform = Platform.Editor;
#else
        platform = Platfor.Mobile;
#endif
    }
}
