namespace Assets.Source.App.Controllers.Spaceship.Attack.Enemy {

  /// <summary>
  /// Controla o comportamento de ataque das naves inimigas
  /// </summary>
  public abstract class EnemyAttackController : AttackController {

    #region Propriedades

    /// <summary>
    /// O tempo entre disparos. É um valor random dentro de uma margem do valor base
    /// </summary>
    public new float shootTimer { get; set; }

    #endregion

  }
}
