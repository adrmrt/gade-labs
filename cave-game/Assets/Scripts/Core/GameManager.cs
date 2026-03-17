using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance { get; private set; }

  public int DeathCount { get; private set; } = 0;
  public bool IsFirstLoad { get; private set; } = true;
  public bool HasFlashlight { get; private set; } = false;
  public bool HasBatteries { get; private set; } = false;

  void Awake()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(gameObject);
      return;
    }
    Instance = this;
    DontDestroyOnLoad(gameObject);
  }

  public void AddDeath() => DeathCount++;
  public void SetFirstLoadDone() => IsFirstLoad = false;
  public void SetHasFlashlight() => HasFlashlight = true;
  public void SetHasBatteries() => HasBatteries = true;
}