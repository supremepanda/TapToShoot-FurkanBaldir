using UnityEngine;

public class Bullet : ProjectileBehaviour
{
    [SerializeField] private float hitForce;
    
    protected override void HitTarget(GameObject target)
    {   
        Debug.Log(target.name);
    }
}