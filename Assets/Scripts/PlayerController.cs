using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

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
        
        _rigidBody.MovePosition(newPosition);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
        Debug.Log(_movement);
    }
}