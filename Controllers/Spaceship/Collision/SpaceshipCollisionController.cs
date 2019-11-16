using UnityEngine;

public class SpaceshipCollisionController : CollisionController {

  /*
   * Retorna verdadeiro se é uma colisão entre essa nave e uma nave ou um escudo inimigo
   */
  protected override bool isCollision () {
    return tagSet.Contains("Player") && (tagSet.Contains("Enemy") || tagSet.Contains("EnemyShield"));
  }

  /*
   * Retorna verdadeiro se um tiro inimigo acertou a nave do jogador ou
   * se o jogador acertou um tiro na nave do inimigo
   */
  protected override bool isBulletCollision () {
    return lifeController.shield <= 0 && (
      (tagSet.Contains("EnemyBullet") && tagSet.Contains("Player")) ||
      (tagSet.Contains("FriendlyBullet") && tagSet.Contains("Enemy"))
    );
  }

  /*
   * Causa dano na nave quando ela é acertada por um tiro
   */
  protected override void onBulletCollision (GameObject bullet) {
    bullet.GetComponent<BulletController>().hitSpaceship(this.gameObject);
  }
}
