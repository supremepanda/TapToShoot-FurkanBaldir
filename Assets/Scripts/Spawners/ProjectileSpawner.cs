using System.Collections.Generic;
using Controllers;
using Managers;
using Projectiles;
using UnityEngine;

namespace Spawners
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> projectiles = new List<GameObject>();
        [SerializeField] private Transform projectileSpawnPosition;
        private RaycastController _raycastController;
        private ProjectileSelectionManager _projectileSelectionManager;
        private void Start()
        {
            _raycastController = FindObjectOfType<RaycastController>();
            _projectileSelectionManager = FindObjectOfType<ProjectileSelectionManager>();
            _raycastController.OnTargetRaycasted += SpawnProjectile;
        }

        private void SpawnProjectile(Transform targetTransform)
        {
            ProjectileType type = _projectileSelectionManager.SelectedProjectileType;
            GameObject newProjectile = Instantiate(projectiles[(int)type], projectileSpawnPosition.position, Quaternion.identity);
            newProjectile.GetComponent<Projectile>().Fire(targetTransform);
        }
    }
}
