using Extensions;

using UnityEngine;

/// <summary>
/// Controla o comportamento de ataque do boss focado em defesa
/// </summary>
public class BossEnemyDefenderAttackController : BossEnemyAttackController {

  #region Meus Métodos

  /// <summary>
  /// Dispara dois tiros na direção do jogador
  /// </summary>
  public override void normalAttack () {
    if (shootTimer.timeIsUp()) {
      for (byte i = 0; i < 2; i++) {
        instantiateRotateAndMoveBullet(weapons[i], iAttack.getPlayerDirection(weapons[i]));
      }
      shootTimer.restart();
    }
  }

  /// <summary>
  /// Instancia e coloca os tiros como filhos do objeto que tem esse script para que eles se movam junto com a nave
  /// </summary>
  public override void specialAttack () {
    for (byte i = 2; i < 4; i++) {
      instantiateBullet(weapons[i], true);
    }
  }

  #endregion

}
