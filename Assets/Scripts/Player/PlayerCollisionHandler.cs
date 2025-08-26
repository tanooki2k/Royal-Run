using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;

    const string hitString = "Hit";
    
    float _cooldownTimer;

    private void Update()
    {
        _cooldownTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if (_cooldownTimer < collisionCooldown) return;
        
        animator.SetTrigger(hitString);
        _cooldownTimer = 0f;
    }
}