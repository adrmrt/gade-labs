using UnityEngine;

public class FlashlightPickup : MonoBehaviour, IPickup
{
  public FlashlightController flashlightController;
  public string PromptText => "[F] Pick up Flashlight";

  public void OnPickup()
  {
    flashlightController.PickupFlashlight();
    Destroy(gameObject);
  }
}
