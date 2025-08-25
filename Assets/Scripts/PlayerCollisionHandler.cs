using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
    }
}
