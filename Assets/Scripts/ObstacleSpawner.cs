using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float obstacleSpawnTime = 3f;

    int _obstaclesSpawned;

    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (_obstaclesSpawned < 5)
        {
            yield return new WaitForSeconds(obstacleSpawnTime);

            Instantiate(obstaclePrefab, transform.position, Quaternion.identity, transform);
            _obstaclesSpawned++;
        }
    }
}