using UnityEngine;

public class Bomb : ProjectileBehaviour
{
    [SerializeField] private float explosionRange;
    
    protected override void HitTarget(GameObject target)
    {
        Debug.Log("bomb");
    }
}