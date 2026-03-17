using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
  public static HUDManager Instance { get; private set; }

  [Header("Title Screen")]
  public GameObject titleScreen;

  [Header("Game HUD")]
  public GameObject gameHUD;
  public TextMeshProUGUI pickupPrompt;
  public TextMeshProUGUI deathCounter;

  [Header("Death Screen")]
  public GameObject deathScreen;

  void Awake()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(gameObject);
      return;
    }
    Instance = this;

    if (GameManager.Instance.IsFirstLoad)
    {
      GameManager.Instance.SetFirstLoadDone();
      titleScreen.SetActive(true);
      gameHUD.SetActive(false);
    }
    else
    {
      titleScreen.SetActive(false);
      gameHUD.SetActive(true);
      UpdateDeathCounter();
    }

    deathScreen.SetActive(false);
  }

  public void HideTitleScreen()
  {
    titleScreen.SetActive(false);
    gameHUD.SetActive(true);
  }

  public void SetPickupPrompt(string text)
  {
    pickupPrompt.text = text;
  }

  public void AddDeath()
  {
    if (GameManager.Instance != null)
    {
      GameManager.Instance.AddDeath();
      UpdateDeathCounter();
    }
  }

  private void UpdateDeathCounter()
  {
    deathCounter.text = "Deaths: " + GameManager.Instance.DeathCount;

    Debug.Log($"Player has died {GameManager.Instance.DeathCount} times.");
  }

  public void ShowDeathScreen()
  {
    gameHUD.SetActive(false);
    deathScreen.SetActive(true);
  }

  public void HideDeathScreen()
  {
    deathScreen.SetActive(false);
    gameHUD.SetActive(true);
  }
}