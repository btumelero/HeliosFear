using Extensions;

using UnityEngine;

/**
 * Controla o comportamento de ataque do boss focado em defesa
 */
public class BossEnemyDefenderAttackController : BossEnemyAttackController {

  #region Variáveis

  public BossEnemyDefenderMovementController movementController { get; set; }

  #endregion

  /**
   * 
   */
  protected override void Update () {
    if (specialShootTimer == null) {
      if (gameObject.isAt(movementController.startingPosition)) {
        specialShootTimer = gameObject.AddComponent<Timer>();
        specialShootTimer.baseTime = Random.Range(8, 10);
      }
    } else {
      if (gameObject.isAt(movementController.startingPosition)) {
        base.Update();
        if (specialShootTimer.timeIsUp()) {
          specialAttack();
          specialShootTimer.restart();
        }
      }
    }
  }

  #region Meus Métodos

  public override void normalAttack () {
    for (byte i = 0; i < 2; i++) {
      instantiateRotateAndMoveBullet(weapons[i], iSpecialAttack.getPlayerDirection(weapons[i]));
    }
  }

  public override void specialAttack () {
    for (byte i = 2; i < 4; i++) {
      instantiateBullet(weapons[i], true);
    }
  }

  #endregion

}
