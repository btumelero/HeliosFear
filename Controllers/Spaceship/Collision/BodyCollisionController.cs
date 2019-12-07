using UnityEngine;

/**
 * Controla o comportamento de colisões da nave
 */
public class BodyCollisionController : SpaceshipCollisionController {

  #region Meus Métods

  /**
   * Retorna verdadeiro se é uma colisão entre essa nave e uma nave ou um escudo inimigo
   */
  protected override bool isCollision () {
    return compareCollidersTags(Enums.Tags.Player, Enums.Tags.Enemy);
  }

  #endregion

}
