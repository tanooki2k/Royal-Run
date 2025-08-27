using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreboardText;

    private int _score;

    public void ChangeScoreBy(int scoreAmountEarned)
    {
        _score += scoreAmountEarned;
        scoreboardText.text = $"Score: {_score:D9}";
    }
}