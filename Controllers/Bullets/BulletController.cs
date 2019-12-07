using UnityEngine;

public abstract class BulletController : MonoBehaviour {

  public GameObject particleEffect;
  public float shootPower;

  /*
   * Dá dano na nave
   */
  public virtual void hitSpaceship (LifeController lifeController) {
    lifeController.hp -= shootPower;
  }

  /*
   * Dá dano no escudo
   */
  public virtual void hitShield (LifeController lifeController) {
    lifeController.shield -= shootPower;
  }

  /*
   * Mostra um efeito e destrói o tiro
   */
  protected virtual void showEffect () {
    Instantiate(particleEffect, transform.position, transform.rotation);
  }
}
