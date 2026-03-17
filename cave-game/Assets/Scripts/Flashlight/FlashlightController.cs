using UnityEngine;
using System.Collections;

public class FlashlightController : MonoBehaviour
{
  public static FlashlightController Instance { get; private set; }

  private Light flashlight;
  private bool hasFlashlight = false;
  private bool hasBatteries = false;

  void Awake()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(gameObject); return;
    }
    Instance = this;

    flashlight = GetComponent<Light>();
    flashlight.enabled = false;
  }

  void Start()
  {
    if (GameManager.Instance.HasFlashlight)
    {
      flashlight.enabled = true;
      if (!GameManager.Instance.HasBatteries)
        StartCoroutine(Flicker());
    }
  }

  public void PickupFlashlight()
  {
    hasFlashlight = true;
    flashlight.enabled = true;
    StartCoroutine(Flicker());
  }

  public void PickupBatteries()
  {
    hasBatteries = true;
    StopFlicker();
  }

  public void StopFlicker()
  {
    StopAllCoroutines();
    flashlight.enabled = hasFlashlight;
  }

  public void ResumeFlicker()
  {
    if (hasFlashlight && !hasBatteries)
    {
      StopAllCoroutines();
      StartCoroutine(Flicker());
    }
  }

  private IEnumerator Flicker()
  {
    while (!hasBatteries)
    {
      flashlight.enabled = false;
      yield return new WaitForSeconds(Random.Range(0.05f, 0.3f));
      flashlight.enabled = true;
      yield return new WaitForSeconds(Random.Range(0.1f, 1.5f));
    }
  }
}