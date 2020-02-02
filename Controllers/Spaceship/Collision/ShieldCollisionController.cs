/// <summary>
/// Controla o comportamento de colisões do escudo
/// </summary>
public class ShieldCollisionController : SpaceshipCollisionController {

  #region Meus Métodos

  /// <summary>
  /// Retorna verdadeiro se é uma colisão entre esse escudo e uma nave ou um escudo inimigo
  /// </summary>
  /// <returns></returns>
  protected override bool isCollision () {
    return compareCollidersTags(Enums.Tags.PlayerShield, Enums.Tags.EnemyShield);
  }

  #endregion
}
