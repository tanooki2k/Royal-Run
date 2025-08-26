using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject mainCamera;
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] Transform chunkParent;

    [Header("Level Settings")] 
    [Tooltip("The amount of chunks we start with")] 
    [SerializeField] int startingChunksAmount = 12;
    [Tooltip("Do not change chunk length value unless chunk prefab size reflects change")] 
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 2f;
    [SerializeField] float maxMoveSpeed = 20f;
    [SerializeField] float minGravityZ = -22f;
    [SerializeField] float maxGravityZ = -2f;

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
        float newMoveSpeed = moveSpeed + speedAmount;
        newMoveSpeed = Mathf.Clamp(newMoveSpeed, minMoveSpeed, maxMoveSpeed);

        if (newMoveSpeed != moveSpeed)
        {
            moveSpeed = newMoveSpeed;

            float newGravityZ = Physics.gravity.z - speedAmount;
            newGravityZ = Mathf.Clamp(newGravityZ, minGravityZ, maxGravityZ);
            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newGravityZ);
            cameraController.ChangeCameraFOV(speedAmount);
        }
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