using UnityEngine;
using UnityEngine.InputSystem;

public class FlashlightPickup : MonoBehaviour
{
  [Header("References")]
  public Light flashlightLight;

  [Header("Settings")]
  public float pickupRange = 2f;
  public KeyCode pickupKey = KeyCode.F;

  private Transform player;
  private bool playerInRange = false;

  void Start()
  {
    player = GameObject.FindWithTag("Player").transform;

    // Make sure light starts off
    if (flashlightLight != null)
    {
      flashlightLight.enabled = false;
    }
  }

  void Update()
  {
    float dist = Vector3.Distance(transform.position, player.position);
    playerInRange = dist <= pickupRange;

    if (playerInRange && Keyboard.current.fKey.wasPressedThisFrame)
    {
      PickUp();
    }
  }

  void PickUp()
  {
    if (flashlightLight != null)
    {
      flashlightLight.enabled = true;
      Debug.Log("Flashlight picked up, light enabled: " + flashlightLight.enabled);
    }
    else
    {
      Debug.Log("flashlightLight is NULL - not assigned in Inspector!");
    }

    Destroy(gameObject);
  }

  void OnGUI()
  {
    if (playerInRange)
    {
      GUIStyle style = new GUIStyle(GUI.skin.label);
      style.fontSize = 18;
      style.normal.textColor = Color.white;
      style.alignment = TextAnchor.MiddleCenter;

      GUI.Label(
          new Rect(Screen.width / 2 - 150, Screen.height / 2 + 40, 300, 30),
          "[F] Pick up Flashlight",
          style
      );
    }
  }
}
