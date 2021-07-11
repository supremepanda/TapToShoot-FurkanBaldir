using System;
using Controllers;
using UnityEngine;

namespace Managers
{
    public class ProjectileSelectionManager : MonoBehaviour
    {
        private ProjectileChangeInputController _projectileChangeInputController;

        private ProjectileType _selectedProjectileType;
        public ProjectileType SelectedProjectileType => _selectedProjectileType;

        private int _indexProjectileType;
        private int _enumLengthProjectileTypes;

        private void Awake()
        {
            InitializeProjectileSelectionManager();
        }

        private void Start()
        {
            _projectileChangeInputController = FindObjectOfType<ProjectileChangeInputController>();
            _projectileChangeInputController.OnProjectileChangedInput += ChangeProjectile;
        }

        private void InitializeProjectileSelectionManager()
        {
            _enumLengthProjectileTypes = Enum.GetNames(typeof(ProjectileType)).Length;
            _selectedProjectileType = ProjectileType.Bullet;
            _indexProjectileType = 0;
        }

        private void ChangeProjectile()
        {
            _indexProjectileType++;
            if (_indexProjectileType >= _enumLengthProjectileTypes)
            {
                _indexProjectileType = 0;
                
            }
            _selectedProjectileType = (ProjectileType) _indexProjectileType;
        }
    }
}