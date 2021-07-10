using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public static ShootManager Instance;

    public bool isShootingEnabled;
    
    private void Awake()
    {
        if (Instance != null) return;
        Instance = this;
        InitializeShootManager();
    }

    private void InitializeShootManager()
    {
        isShootingEnabled = true;
    }
}