using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    
    const string PlayerString = "Player";

    void Update()
    {
        transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerString))
        {
            OnPickUp();
            Destroy(gameObject);
        }
    }

    protected abstract void OnPickUp();
}