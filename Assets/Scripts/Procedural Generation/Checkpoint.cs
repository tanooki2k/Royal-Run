using UnityEngine;

public class Checkpoint : MonoBehaviour
{
   [SerializeField] float checkpointTimeExtension = 5f;
   [SerializeField] float obstacleDecreaseTimeAmount = .2f;

    GameManager _gameManager;
    ObstacleSpawner _obstacleSpawner;

    const string PlayerString = "Player";

    private void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
        _obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (_gameManager.GameOver || !other.CompareTag(PlayerString)) return;
        
        _gameManager.ChangeTimeBy(checkpointTimeExtension);
        _obstacleSpawner.DecreaseObstacleSpawnTime(obstacleDecreaseTimeAmount);
    }
}
