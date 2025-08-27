using UnityEngine;

public class Apple : PickUp
{
    [SerializeField] float adjustChangeMoveSpeedAmount = 3f;

    LevelGenerator _levelGenerator;

    public void Init(LevelGenerator levelGenerator)
    {
        this._levelGenerator = levelGenerator;
    }

    protected override void OnPickUp()
    {
        _levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
    }
}
