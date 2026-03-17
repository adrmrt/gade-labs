using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDeath : MonoBehaviour
{
  [Header("Audio")]
  public AudioSource deathSound;

  public readonly Vector3 spawnPoint = new Vector3(0f, 1.25f, 0f);

  private bool isDead = false;

  void Update()
  {
    if (isDead && Keyboard.current.rKey.wasPressedThisFrame)
    {
      Respawn();
    }
  }

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Wall"))
    {
      Die();
    }
  }

  void Die()
  {
    if (isDead) return;

    deathSound.Play();
    isDead = true;

    if (HUDManager.Instance != null)
    {
      HUDManager.Instance.AddDeath();
      HUDManager.Instance.ShowDeathScreen();
    }

    FlashlightController.Instance.StopFlicker();

    // Freeze player movement and disable controls
    GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
    GetComponent<PlayerMovement>().enabled = false;
    GetComponentInChildren<MouseLook>().enabled = false;
  }

  void Respawn()
  {
    isDead = false;

    transform.position = spawnPoint;
    transform.rotation = Quaternion.identity;

    GetComponent<PlayerMovement>().enabled = true;
    GetComponentInChildren<MouseLook>().enabled = true;
    GetComponent<Rigidbody>().linearVelocity = Vector3.zero;

    FlashlightController.Instance.ResumeFlicker();

    if (HUDManager.Instance != null)
    {
      HUDManager.Instance.HideDeathScreen();
    }
  }
}