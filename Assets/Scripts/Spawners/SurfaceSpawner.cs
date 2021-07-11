using System;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawners
{
    public class SurfaceSpawner : MonoBehaviour
    {
        [SerializeField] private int _rows;
        [SerializeField] private int _columns;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private List<GameObject> _surfaces = new List<GameObject>();
        private ProgressController _progressController;
        private int _surfaceEnumLength;

        private void Start()
        {
            _progressController = FindObjectOfType<ProgressController>();
            _progressController.TargetAmount = _rows * _columns;
            _surfaceEnumLength = Enum.GetNames(typeof(SurfaceType)).Length;
            SpawnSurfaces();
        }

        private void SpawnSurfaces()
        {
            _offset.x = -_columns / 2f;
            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _columns; column++)
                {
                    int surfaceIndex = Random.Range(0, _surfaceEnumLength);
                    Vector3 spawnPosition = new Vector3(column + _offset.x, row + _offset.y, 0 + _offset.z);
                    Instantiate(_surfaces[surfaceIndex], spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}
