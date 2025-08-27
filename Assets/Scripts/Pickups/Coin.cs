using System;
using UnityEngine;

public class Coin : PickUp
{
    [SerializeField] int scoreAmountEarned = 100;
    
    ScoreManager _scoreManager;

    public void Init(ScoreManager scoreManager)
    {
        this._scoreManager = scoreManager;
    }

    protected override void OnPickUp()
    {
        _scoreManager.ChangeScoreBy(scoreAmountEarned);
    }
}
