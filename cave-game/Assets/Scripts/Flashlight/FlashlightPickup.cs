using UnityEngine;

public class FlashlightPickup : MonoBehaviour, IPickup
{
  public FlashlightController flashlightController;
  public string PromptText => "[F] Pick up Flashlight";

  void Start()
  {
    if (GameManager.Instance.HasFlashlight)
    {
      Destroy(gameObject);
    }
  }

  public void OnPickup()
  {
    GameManager.Instance.SetHasFlashlight();
    flashlightController.PickupFlashlight();
    Destroy(gameObject);
  }
}
