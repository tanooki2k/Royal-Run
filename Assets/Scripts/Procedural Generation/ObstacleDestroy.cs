using UnityEngine;

public class ObstacleDestroy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Elimination");
        Destroy(other.gameObject);
    }
}
