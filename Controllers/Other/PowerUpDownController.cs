using UnityEngine;

public class PowerUpDownController : MonoBehaviour {

  public bool isPowerUp;

  /*
   * Se pegar um power up ou down ajusta o número de tiros que a nave dispara por vez
   */
  public void OnTriggerEnter (Collider other) {
    if (other.gameObject.tag == "Player") {
      PlayerAttackController player = other.gameObject.GetComponentInParent<PlayerAttackController>();
      if (isPowerUp) {
        if (player.bulletsPerFire < 3) {
          player.bulletsPerFire++;
        }
      } else {
        if (player.bulletsPerFire > 1) {
          player.bulletsPerFire--;
        }
      }
      Destroy(gameObject);
    }
  }
}
