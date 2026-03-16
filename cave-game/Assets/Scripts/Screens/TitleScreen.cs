using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
  [Header("UI")]
  public TextMeshProUGUI gameTitleText;
  public TextMeshProUGUI pressAnyKeyText;

  [Header("Content")]
  public string gameTitle = "Cave Game";
  public string pressAnyKeyPrompt = "Press any key to start";

  private bool ready = false;

  void Start()
  {
    gameTitleText.text = gameTitle;
    pressAnyKeyText.text = pressAnyKeyPrompt;

    // Freeze player
    var player = GameObject.FindWithTag("Player");
    player.GetComponent<PlayerMovement>().enabled = false;
    player.GetComponentInChildren<MouseLook>().enabled = false;

    // Wait before accepting input
    Invoke(nameof(SetReady), 0.5f);
  }

  void SetReady()
  {
    ready = true;
  }

  void Update()
  {
    if (!ready) return;

    if (Keyboard.current.anyKey.wasPressedThisFrame)
    {
      var player = GameObject.FindWithTag("Player");
      player.GetComponent<PlayerMovement>().enabled = true;
      player.GetComponentInChildren<MouseLook>().enabled = true;
      HUDManager.Instance.HideTitleScreen();
    }
  }
}