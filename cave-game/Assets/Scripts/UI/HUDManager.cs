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

  private int deathCount = 0;

  void Awake()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(gameObject);
      return;
    }
    Instance = this;

    titleScreen.SetActive(true);
    gameHUD.SetActive(false);
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
    deathCount++;
    UpdateDeathCounter();
  }

  private void UpdateDeathCounter()
  {
    string skulls = "";
    for (int i = 0; i < deathCount; i++)
    {
      skulls += "💀";
    }
    deathCounter.text = skulls;
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