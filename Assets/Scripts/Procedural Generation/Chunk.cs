using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Header("Fence Reference")] 
    
    [Tooltip("Insert the model to spawn as a fence (obstacle)")] 
    [SerializeField] GameObject fencePrefab;

    
    [Header("Apple Settings")]
    
    [Tooltip("Insert the reference for the apple (a prefab with colliders)")] 
    [SerializeField] GameObject applePrefab;

    [Tooltip("The chances of spawning an apple per each chunk")] 
    [SerializeField] [Range(0f, 1f)] float appleSpawnChance = .3f;

    
    [Header("Coin Settings")] 
    
    [Tooltip("Insert the reference for the coin (a prefab with colliders)")] 
    [SerializeField] GameObject coinPrefab;

    [Tooltip("The chances of spawning a coin per each chunk")] [SerializeField] [Range(0f, 1f)]
    float coinSpawnChance = .5f;

    [Tooltip("The distance between each coin of a group of coins generated")] 
    [SerializeField] [Range(0f, 2f)] float coinSeparationLength = 2f;

    [Header("Lanes Position")] 
    
    [Tooltip("Determine where the fences and pick-ups will be placed")] 
    [SerializeField] float[] lanes = { -1.6f, 0f, 1.6f };

    private List<int> _availableLanes;

    void Start()
    {
        _availableLanes = new List<int> { 0, 1, 2 };

        SpawnFences();
        SpawnApple();
        SpawnCoins();
    }

    void SpawnFences()
    {
        int fencesToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (_availableLanes.Count <= 0) break;

            int selectedLane = SelectLane();

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    void SpawnApple()
    {
        if (Random.value > appleSpawnChance || _availableLanes.Count <= 0) return;

        int selectedLane = SelectLane();

        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform);
    }

    void SpawnCoins()
    {
        if (Random.value > coinSpawnChance || _availableLanes.Count <= 0) return;

        int selectedLane = SelectLane();

        int maxCoinsToSpawn = 6;
        int coinsToSpawn = Random.Range(1, maxCoinsToSpawn);

        float topOfChunkZPos = transform.position.z + (coinSeparationLength * 2f);

        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnPositionZ = topOfChunkZPos - (i * coinSeparationLength);
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, spawnPositionZ);
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, _availableLanes.Count);
        int selectedLane = _availableLanes[randomLaneIndex];
        _availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }
}