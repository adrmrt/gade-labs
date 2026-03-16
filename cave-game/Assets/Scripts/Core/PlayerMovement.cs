using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  public float speed = 10f;
  public float sprintMultiplier = 2f;
  private Rigidbody rb;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  void FixedUpdate()
  {
    Vector2 input = Vector2.zero;
    if (Keyboard.current.dKey.isPressed) input.x += 1;
    if (Keyboard.current.aKey.isPressed) input.x -= 1;
    if (Keyboard.current.wKey.isPressed) input.y += 1;
    if (Keyboard.current.sKey.isPressed) input.y -= 1;

    bool isSprinting = Keyboard.current.leftShiftKey.isPressed;
    float currentSpeed = isSprinting ? speed * sprintMultiplier : speed;

    Vector3 move = transform.right * input.x + transform.forward * input.y;
    move = move.normalized * currentSpeed;
    move.y = rb.linearVelocity.y;
    rb.linearVelocity = move;
  }
}
