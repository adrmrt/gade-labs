using UnityEngine;
using TMPro;

public class DeathScreen : MonoBehaviour
{
  [Header("UI")]
  public TextMeshProUGUI deathTitleText;
  public TextMeshProUGUI respawnPromptText;

  [Header("Content")]
  public string deathTitle = "YOU DIED";
  public string respawnPrompt = "Press R to respawn";

  void Awake()
  {
    deathTitleText.text = "";
    respawnPromptText.text = "";
  }

  void Start()
  {
    deathTitleText.text = deathTitle;
    respawnPromptText.text = respawnPrompt;
  }
}