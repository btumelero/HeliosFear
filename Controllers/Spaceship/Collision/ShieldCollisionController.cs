using UnityEngine;

public class ShieldCollisionController : CollisionController {

  #region Meus Métodos

  /*
   * Retorna verdadeiro se é uma colisão entre esse escudo e uma nave ou um escudo inimigo
   */
  protected override bool isCollision () {
    return tagSet.Contains(Enums.Tags.PlayerShield.ToString()) && 
      (tagSet.Contains(Enums.Tags.EnemyShield.ToString()) || tagSet.Contains(Enums.Tags.Enemy.ToString()));
  }

  /*
   * Retorna verdadeiro se um tiro inimigo acertou o escudo do jogador ou
   * se o jogador acertou um tiro no escudo do inimigo
   */
  protected override bool isBulletCollision () {
    return 
      (tagSet.Contains(Enums.Tags.EnemyBullet.ToString()) && tagSet.Contains(Enums.Tags.PlayerShield.ToString())) ||
      (tagSet.Contains(Enums.Tags.FriendlyBullet.ToString()) && tagSet.Contains(Enums.Tags.EnemyShield.ToString()));
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
