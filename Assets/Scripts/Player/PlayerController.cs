using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Gameplay Configurations")] 
    [Tooltip("How fast does the player move")] [SerializeField] float moveSpeed = 10f;
    [Tooltip("How far the player can go on the x-axis from the initial position")] [SerializeField] float xClamp = 5f;
    [Tooltip("How far the player can go on the z-axis from the initial position")] [SerializeField] float zClamp = 2.5f;

    Rigidbody _rigidBody;
    Vector2 _movement;


    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 currentPosition = _rigidBody.position;
        Vector3 moveDirection = new Vector3(_movement.x, 0f, _movement.y);
        Vector3 newPosition = currentPosition + moveDirection * (moveSpeed * Time.fixedDeltaTime);

        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
        newPosition.z = Mathf.Clamp(newPosition.z, -zClamp, zClamp);

        _rigidBody.MovePosition(newPosition);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }
}