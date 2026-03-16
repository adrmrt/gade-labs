using UnityEngine;

public class BatteryPickup : MonoBehaviour, IPickup
{
  public FlashlightController flashlightController;
  public string PromptText => "[F] Pick up Batteries";

  public void OnPickup()
  {
    flashlightController.PickupBatteries();
    Destroy(gameObject);
  }
}