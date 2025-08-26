using System;
using UnityEngine;

public class Apple : PickUp
{
    [SerializeField] float increaseMoveSpeed = 3f;

    LevelGenerator _levelGenerator;

    private void Start()
    {
        _levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    protected override void OnPickUp()
    {
        _levelGenerator.ChangeChunkMoveSpeed(increaseMoveSpeed);
    }
}
