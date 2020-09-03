/// <summary>
/// Controla o comportamento de ataque das naves inimigas
/// </summary>
public abstract class EnemyAttackController : AttackController {

  #region Meus Métodos

  /// <summary>
  /// Dispara um tiro de cada arma, faz ele se mover e rotaciona na direção do movimento
  /// </summary>
  public override void normalAttack () {
    if (shootTimer.timeIsUp()) {
      for (byte i = 0; i < weapons.Length; i++) {
        instantiateRotateAndMoveBullet(weapons[i]);
      }
      shootTimer.restart();
    }
  }

  #endregion

}
