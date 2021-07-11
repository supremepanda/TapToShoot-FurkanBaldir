using System;
using System.Collections.Generic;
using Controllers;
using Managers;
using Projectiles;
using UnityEngine;

namespace Spawners
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _projectiles = new List<GameObject>();
        [SerializeField] private Transform _projectileSpawnPosition;
        private RaycastController _raycastController;
        private ProjectileSelectionManager _projectileSelectionManager;
        private ProjectileType _selectedProjectileType;
        
        private void OnDestroy()
        {
            _raycastController.OnTargetRayCasted -= SpawnProjectile;
            _projectileSelectionManager.OnSelectedProjectile -= ChangeCurrentSelectedProjectile;
        }
        private void Start()
        {
            _raycastController = FindObjectOfType<RaycastController>();
            _projectileSelectionManager = FindObjectOfType<ProjectileSelectionManager>();
            
            _raycastController.OnTargetRayCasted += SpawnProjectile;
            _projectileSelectionManager.OnSelectedProjectile += ChangeCurrentSelectedProjectile;
        }

        private void ChangeCurrentSelectedProjectile(ProjectileType type)
        {
            _selectedProjectileType = type;
        }

        private void SpawnProjectile(Transform targetTransform)
        {
            GameObject newProjectile = Instantiate(_projectiles[(int)_selectedProjectileType], _projectileSpawnPosition.position, Quaternion.identity);
            newProjectile.GetComponent<Projectile>().Fire(targetTransform);
        }
    }
}
