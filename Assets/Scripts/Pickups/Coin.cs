using System;
using UnityEngine;

public class Coin : PickUp
{
    [SerializeField] int scoreAmountEarned = 100;
    
    ScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    protected override void OnPickUp()
    {
        _scoreManager.ChangeScoreBy(scoreAmountEarned);
    }
}
