using UnityEngine;
using UnityEngine.InputSystem;

public class PickupInteractor : MonoBehaviour
{
  public float pickupRange = 2.5f;
  private IPickup currentPickup;

  void Update()
  {
    // Find nearest pickup in range
    Collider[] hits = Physics.OverlapSphere(transform.position, pickupRange);
    currentPickup = null;

    foreach (var hit in hits)
    {
      IPickup pickup = hit.GetComponent<IPickup>();
      if (pickup != null)
      {
        currentPickup = pickup;
        break;
      }
    }

    // Update prompt
    if (HUDManager.Instance != null)
    {
      HUDManager.Instance.SetPickupPrompt(currentPickup != null ? currentPickup.PromptText : "");
    }

    // Interact
    if (currentPickup != null && Keyboard.current.fKey.wasPressedThisFrame)
    {
      currentPickup.OnPickup();
    }
  }

  void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(transform.position, pickupRange);
  }
}