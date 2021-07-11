using System;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawners
{
    public class SurfaceSpawner : MonoBehaviour
    {
        [SerializeField] private int rows;
        [SerializeField] private int columns;
        [SerializeField] private Vector3 offset;
        [SerializeField] private List<GameObject> surfaces = new List<GameObject>();

        private ProgressController _progressController;
        
        private int _surfaceEnumLength;

        private void Start()
        {
            _progressController = FindObjectOfType<ProgressController>();
            _progressController.TargetAmount = rows * columns;
            _surfaceEnumLength = Enum.GetNames(typeof(SurfaceType)).Length;
            SpawnSurfaces();
        }

        private void SpawnSurfaces()
        {
            offset.x = -columns / 2f;
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    int surfaceIndex = Random.Range(0, _surfaceEnumLength);
                    Vector3 spawnPosition = new Vector3(column + offset.x, row + offset.y, 0 + offset.z);
                    Instantiate(surfaces[surfaceIndex], spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}
