using Extensions;
using Interfaces;

/**
 * Controla o comportamento de ataque da nave focada em defesa
 */
public class CommonEnemyDefenderAttackController : CommonEnemyAttackController, ISpecialAttack {
  #region Getters e Setters

  public ISpecialAttack iSpecialAttack {
    get => this as ISpecialAttack;
  }

  #endregion

  #region Meus Métodos

  /**
   * Esse tipo de nave atira um tiro na direção do jogador
   */
  public void specialAttack () {
    instantiateRotateAndMoveBullet(weapons[0], iSpecialAttack.getPlayerDirection(weapons[0]));
  }

  #endregion

}