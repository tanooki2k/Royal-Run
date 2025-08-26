using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Insert all the obstacles to be displayed")]
    [SerializeField] GameObject[] obstaclePrefabs;
    [Tooltip("Insert the object where the obstacles GameObjects will be stored at")]
    [SerializeField] Transform obstacleParent;
    
    [Header("Obstacles Settings")]
    [SerializeField] float obstacleSpawnTime = 3f;
    [Tooltip("Determine the range of positions centered to the screen for all obstacles")] 
    [SerializeField] float spawnWidth = 8f;

    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPosition = Random.Range(-spawnWidth / 2, spawnWidth / 2) * Vector3.right + transform.position;
            yield return new WaitForSeconds(obstacleSpawnTime);
            Instantiate(obstaclePrefab, spawnPosition, Random.rotation, obstacleParent);
        }
    }
}