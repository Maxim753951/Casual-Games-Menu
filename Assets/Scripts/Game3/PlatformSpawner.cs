using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private GameObject _platformPrefab;

    [SerializeField] private float _verticalOffset = 1f;

    private float? _lastPointPositionY = null;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        Transform randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        float spawnPointPositionY = _lastPointPositionY == null ? randomSpawnPoint.position.y : (float)_lastPointPositionY + _verticalOffset;

        randomSpawnPoint.position = new Vector3(randomSpawnPoint.position.x, spawnPointPositionY, randomSpawnPoint.position.z);
        _lastPointPositionY = spawnPointPositionY;

        Instantiate(_platformPrefab, randomSpawnPoint.position, Quaternion.identity);
    }
}
