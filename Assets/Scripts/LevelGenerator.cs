using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] Transform chunkParent;

    [SerializeField] float chunkLength = 10f;

    void Start()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            Vector3 chunkSpawnPos = Vector3.forward * (chunkLength * i);
            Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);
        }
    }
}