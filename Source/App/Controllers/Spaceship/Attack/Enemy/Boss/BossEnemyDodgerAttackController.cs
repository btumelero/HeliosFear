using UnityEngine;

/// <summary>
/// Classe responsável por controlar o comportamento de ataque do boss focado em velocidade
/// </summary>
public class BossEnemyDodgerAttackController : BossEnemyAttackController {

  #region Variáveis


  #endregion

  #region Meus Métodos

  /// <summary>
  /// Dispara um tiro para baixo
  /// </summary>
  public override void normalAttack () {
    if (shootTimer.timeIsUp()) {
      instantiateBullet(weapons[0], true);
      shootTimer.restart();
    }
  }

  /// <summary>
  /// Dispara um tiro para cima e outro para baixo
  /// </summary>
  public override void specialAttack () {
    if (specialShootTimer.timeIsUp()) {
      instantiateBullet(weapons[1], false);
      instantiateBullet(weapons[2], false);
      specialShootTimer.baseTime = Random.Range(0.1f, 0.5f);
      specialShootTimer.restart();
    }
  }

  #endregion

}
