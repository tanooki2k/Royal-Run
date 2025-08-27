using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] TextMeshProUGUI scoreboardText;

    private int _score;

    public void ChangeScoreBy(int scoreAmountEarned)
    {
        if (gameManager.GameOver) return;
        
        _score += scoreAmountEarned;
        scoreboardText.text = $"Score: {_score:D9}";
    }
}