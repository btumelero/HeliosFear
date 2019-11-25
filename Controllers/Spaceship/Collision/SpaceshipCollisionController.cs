using UnityEngine;

public class SpaceshipCollisionController : CollisionController {

  #region Meus Métods

  /*
   * Retorna verdadeiro se é uma colisão entre essa nave e uma nave ou um escudo inimigo
   */
  protected override bool isCollision () {
    return tagSet.Contains(Enums.Tags.Player.ToString()) && 
      (tagSet.Contains(Enums.Tags.Enemy.ToString()) || tagSet.Contains(Enums.Tags.EnemyShield.ToString()));
  }

  /*
   * Retorna verdadeiro se um tiro inimigo acertou a nave do jogador ou
   * se o jogador acertou um tiro na nave do inimigo
   */
  protected override bool isBulletCollision () {
    return lifeController.shield <= 0 && 
      (
        (tagSet.Contains(Enums.Tags.EnemyBullet.ToString()) && tagSet.Contains(Enums.Tags.Player.ToString())) ||
        (tagSet.Contains(Enums.Tags.FriendlyBullet.ToString()) && tagSet.Contains(Enums.Tags.Enemy.ToString())
      )
    );
  }

  /*
   * Causa dano na nave quando ela é acertada por um tiro
   */
  protected override void onBulletCollision (GameObject bullet) {
    bullet.GetComponent<BulletController>().hitSpaceship(this.gameObject);
  }

  #endregion

}
