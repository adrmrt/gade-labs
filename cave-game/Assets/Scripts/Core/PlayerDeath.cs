using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDeath : MonoBehaviour
{
  public AudioSource deathSound;
  private bool isDead = false;

  void Update()
  {
    if (isDead && Keyboard.current.rKey.wasPressedThisFrame)
    {
      UnityEngine.SceneManagement.SceneManager.LoadScene(
        UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
      );
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

    HUDManager.Instance.AddDeath();
    HUDManager.Instance.ShowDeathScreen();

    FlashlightController.Instance.StopFlicker();

    // Freeze player movement and disable controls
    GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
    GetComponent<PlayerMovement>().enabled = false;
    GetComponentInChildren<MouseLook>().enabled = false;
  }
}
