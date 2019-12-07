using UnityEngine;

/**
 * Controla o comportamento de colisões do escudo
 */
public class ShieldCollisionController : SpaceshipCollisionController {

  #region Meus Métodos

  /**
   * Retorna verdadeiro se é uma colisão entre esse escudo e uma nave ou um escudo inimigo
   */
  protected override bool isCollision () {
    return compareCollidersTags(Enums.Tags.PlayerShield, Enums.Tags.EnemyShield);
  }

  #endregion
}
