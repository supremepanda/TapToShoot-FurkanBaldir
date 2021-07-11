using System;
using Controllers;
using UnityEngine;

namespace Managers
{
    public class ProjectileSelectionManager : MonoBehaviour
    {
        private TapInputController _tapInputController;
        private ProjectileType _selectedProjectileType;
        private int _indexProjectileType;
        private int _enumLengthProjectileTypes;
        
        private void OnDestroy()
        {
            _tapInputController.OnProjectileChangedInput -= ChangeProjectile;
        }
        
        public delegate void ChangeSelectedProjectile(ProjectileType selectedProjectileType);
        public event ChangeSelectedProjectile OnSelectedProjectile;
        
        private void Awake()
        {
            InitializeProjectileSelectionManager();
        }

        private void Start()
        {
            _tapInputController = FindObjectOfType<TapInputController>();
            _tapInputController.OnProjectileChangedInput += ChangeProjectile;
            OnSelectedProjectile?.Invoke(_selectedProjectileType);

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
            OnSelectedProjectile?.Invoke(_selectedProjectileType);
        }
    }
}