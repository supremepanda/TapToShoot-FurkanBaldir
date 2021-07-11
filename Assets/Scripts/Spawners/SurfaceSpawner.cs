using System;
using System.Collections.Generic;
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

        private int _surfaceEnumLength;

        private void Start()
        {
            _surfaceEnumLength = Enum.GetNames(typeof(SurfaceType)).Length;
            SpawnSurfaces();
        }

        private void SpawnSurfaces()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    int surfaceIndex = Random.Range(0, _surfaceEnumLength);
                    Vector3 spawnPosition = new Vector3(row + offset.x, column + offset.y, 0 + offset.z);
                    Instantiate(surfaces[surfaceIndex], spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}
