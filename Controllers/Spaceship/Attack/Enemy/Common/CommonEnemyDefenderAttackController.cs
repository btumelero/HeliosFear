using Extensions;

using Interfaces;

/// <summary>
/// Controla o comportamento de ataque da nave focada em defesa
/// </summary>
public class CommonEnemyDefenderAttackController : CommonEnemyAttackController {

  #region Getters e Setters

  /// <summary>
  /// Para acessar os métodos de extensão da interface
  /// </summary>
  public IAttack iAttack {
    get => this as IAttack;
  }

  #endregion

  #region Meus Métodos

  /// <summary>
  /// Esse tipo de nave atira um tiro na direção do jogador
  /// </summary>
  public override void normalAttack () {
    if (shootTimer.timeIsUp()) {
      instantiateRotateAndMoveBullet(weapons[0], iAttack.getPlayerDirection(weapons[0]));
      shootTimer.restart();
    }
  }

  #endregion

}