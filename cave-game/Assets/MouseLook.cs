using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
  public float sensitivity = 0.1f;
  private float xRotation = 0f;

  void Start()
  {
    Cursor.lockState = CursorLockMode.Locked; // Hides and locks the cursor to the center of the screen
  }

  // Update is called once per frame
  void Update()
  {
    Vector2 mouseDelta = Mouse.current.delta.ReadValue();

    float mouseX = mouseDelta.x * sensitivity;
    float mouseY = mouseDelta.y * sensitivity;

    xRotation -= mouseY;
    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    transform.parent.Rotate(Vector3.up * mouseX);
  }
}
