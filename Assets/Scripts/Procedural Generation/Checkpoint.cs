using UnityEngine;

public class Checkpoint : MonoBehaviour
{
   [SerializeField] float checkpointTimeExtension = 5f;

    GameManager _gameManager;

    const string PlayerString = "Player";

    private void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (_gameManager.GameOver || !other.CompareTag(PlayerString)) return;
        
        _gameManager.ChangeTimeBy(checkpointTimeExtension);
    }
}
