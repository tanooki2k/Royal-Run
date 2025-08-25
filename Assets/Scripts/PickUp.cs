using UnityEngine;

public class PickUp : MonoBehaviour
{
    const string PlayerString = "Player";
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerString))
        {
            Debug.Log(other.gameObject.name);
        }
    }
}