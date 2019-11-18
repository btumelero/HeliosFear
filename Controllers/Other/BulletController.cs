using UnityEngine;

public class BulletController : MonoBehaviour {

  public GameObject particleEffect;
  public float shootPower { get; set; }

  /*
   * Dá dano na nave
   */
  public void hitSpaceship (GameObject spaceship) {
    spaceship.GetComponentInParent<LifeController>().hp -= shootPower;
    showEffectAndDestroySelf();
  }

  /*
   * Dá dano no escudo
   */
  public void hitShield (GameObject spaceship) {
    spaceship.GetComponentInParent<LifeController>().shield -= shootPower;
    showEffectAndDestroySelf();
  }

  /*
   * Mostra um efeito e destrói o tiro
   */
  private void showEffectAndDestroySelf () {
    Instantiate(particleEffect, transform.position, transform.rotation);
    Destroy(gameObject);
  }
}
