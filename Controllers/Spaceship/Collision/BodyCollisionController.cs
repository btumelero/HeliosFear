/// <summary>
/// Controla o comportamento de colisões da nave
/// </summary>
public class BodyCollisionController : SpaceshipCollisionController {

  #region Meus Métods

  /// <summary>
  /// Retorna verdadeiro se é uma colisão entre essa nave e uma nave ou um escudo inimigo
  /// </summary>
  /// 
  /// <returns>
  /// Verdadeiro se é uma colisão nave-nave inimiga ou nave-escudo inimigo
  /// </returns>
  protected override bool isCollision () {
    return compareCollidersTags(Enums.Tags.Player, Enums.Tags.Enemy);
  }

  #endregion

}
