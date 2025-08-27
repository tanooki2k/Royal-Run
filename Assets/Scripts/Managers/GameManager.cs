using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime = 5f;

    private float _timeLeft;
    private bool _gameOver = false;

    private void Start()
    {
        _timeLeft = startTime;
    }

    private void Update()
    {
        DecreaseTime();
    }

    private void DecreaseTime()
    {
        if (_gameOver) return;
        
        _timeLeft -= Time.deltaTime;
        timeText.text = $"Time: {_timeLeft:F1}";

        if (_timeLeft <= 0f)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        _gameOver = true;
        playerController.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = .1f;
    }
}
