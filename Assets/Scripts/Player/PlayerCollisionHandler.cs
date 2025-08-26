using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator animator;
    
    [Header("Knockback Settings")]
    [SerializeField] float collisionCooldown = 1f;
    [SerializeField] float adjustChangeMoveSpeedAmount = -2f;

    const string HitString = "Hit";
    
    float _cooldownTimer;

    private LevelGenerator _levelGenerator;

    void Start()
    {
        _levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }
    
    private void Update()
    {
        _cooldownTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if (_cooldownTimer < collisionCooldown) return;
        
        _levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
        animator.SetTrigger(HitString);
        _cooldownTimer = 0f;
    }
}