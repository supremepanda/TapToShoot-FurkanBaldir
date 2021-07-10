using System;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform projectileSpawnPosition;
    private RaycastController _raycastController;
    private void Start()
    {
        _raycastController = FindObjectOfType<RaycastController>();
        _raycastController.OnTargetRaycasted += SpawnProjectile;
    }

    private void SpawnProjectile(Transform targetTransform)
    {
        GameObject newProjectile = Instantiate(projectile, projectileSpawnPosition.position, Quaternion.identity);
        newProjectile.GetComponent<Projectile>().Fire(targetTransform);
    }
}
