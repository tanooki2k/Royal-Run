using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Chunks Settings")]
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 2f;
    
    [Header("Chunk Storage")]
    [SerializeField] Transform chunkParent;
    
    [Header("Camera")]
    [SerializeField] GameObject mainCamera;

    List<GameObject> _chunks;

    void Start()
    {
        _chunks = new List<GameObject>();
        SpawnStartingChunks();
    }

    void Update()
    {
        MoveChunks();
    }

    public void ChangeChunkMoveSpeed(float speedAmount)
    {
        moveSpeed += speedAmount;

        if (moveSpeed < minMoveSpeed)
        {
            moveSpeed = minMoveSpeed;
        }

        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, Physics.gravity.z - speedAmount);
    }

    void SpawnStartingChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            SpawnChunk();
        }
    }

    void SpawnChunk()
    {
        Vector3 chunkSpawnPos = CalculateSpawnPosVector3();
        GameObject newChunk = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);

        _chunks.Add(newChunk);
    }

    Vector3 CalculateSpawnPosVector3()
    {
        Vector3 movementVector = Vector3.forward * (chunkLength * _chunks.Count) + transform.position;

        if (_chunks.Count >= startingChunksAmount)
        {
            float zCameraOffset = mainCamera.transform.position.z;
            movementVector.z += zCameraOffset - chunkLength;
        }

        return movementVector;
    }

    void MoveChunks()
    {
        for (int i = 0; i < _chunks.Count; i++)
        {
            GameObject chunk = _chunks[i];

            Vector3 displacement = Vector3.back * (moveSpeed * Time.deltaTime);
            chunk.transform.Translate(displacement);

            if (chunk.transform.position.z <= mainCamera.transform.position.z - chunkLength)
            {
                SpawnChunk();
                _chunks.Remove(chunk);
                Destroy(chunk);
            }
        }
    }
}