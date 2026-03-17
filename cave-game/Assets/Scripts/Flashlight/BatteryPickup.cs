using UnityEngine;

public class BatteryPickup : MonoBehaviour, IPickup
{
  public FlashlightController flashlightController;
  public string PromptText => "[F] Pick up Batteries";

  void Start()
  {
    if (GameManager.Instance.HasBatteries)
    {
      Destroy(gameObject);
    }
  }

  public void OnPickup()
  {
    GameManager.Instance.SetHasBatteries();
    flashlightController.PickupBatteries();
    Destroy(gameObject);
  }
}