using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDeath : MonoBehaviour
{
  public AudioSource deathSound;

  public GameObject deathScreen;
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
    deathSound.Play();

    isDead = true;
    deathScreen.SetActive(true);

    // Freeze player movement
    GetComponent<Rigidbody>().linearVelocity = Vector3.zero;

    // Disable scripts
    GetComponent<PlayerMovement>().enabled = false;
    GetComponentInChildren<MouseLook>().enabled = false;
  }
}
