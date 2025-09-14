using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] AudioSource boulderSmashAudio;
    [SerializeField] float shakeModifier = 10f;
    [SerializeField] float collisionCooldown = 1f;

    CinemachineImpulseSource _cinemachineImpulseSource;
    float _collisionTimer;

    void Awake()
    {
        _cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void Update()
    {
        _collisionTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if (_collisionTimer < collisionCooldown) return;
        _collisionTimer = 0f;
        
        FireImpulse();
        CollisionFX(other);
    }

    private void FireImpulse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = (1f / distance) * shakeModifier;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);

        _cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }

    void CollisionFX(Collision other)
    {
        ContactPoint contactPoint = other.contacts[0];
        collisionParticleSystem.transform.position = contactPoint.point;
        collisionParticleSystem.Play();
        boulderSmashAudio.Play();
    }
}