using UnityEngine;

public class ShieldCollisionController : CollisionController {

  #region Meus Métodos

  /*
   * Retorna verdadeiro se é uma colisão entre esse escudo e uma nave ou um escudo inimigo
   */
  protected override bool isCollision () {
    return tagSet.Contains("PlayerShield") && (tagSet.Contains("EnemyShield") || tagSet.Contains("Enemy"));
  }

  /*
   * Zera o escudo da nave quando ela colide contra escudos ou naves inimigas
   */
  protected override void onCollision (GameObject spaceship) {
    base.onCollision(spaceship);
    lifeController.shield = 0;
  }

  /*
   * Retorna verdadeiro se um tiro inimigo acertou o escudo do jogador ou
   * se o jogador acertou um tiro no escudo do inimigo
   */
  protected override bool isBulletCollision () {
    return 
      (tagSet.Contains("EnemyBullet") && tagSet.Contains("PlayerShield")) ||
      (tagSet.Contains("FriendlyBullet") && tagSet.Contains("EnemyShield"));
  }

  /*
   * Causa dano no escudo quando ele é acertado por um tiro
   */
  protected override void onBulletCollision (GameObject bullet) {
    bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
    bullet.GetComponent<BulletController>().hitShield(gameObject);
  }

  #endregion
}
