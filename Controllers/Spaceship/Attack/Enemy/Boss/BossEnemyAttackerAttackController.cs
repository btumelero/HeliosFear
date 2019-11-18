using UnityEngine;

public class BossEnemyAttackerAttackController : EnemyAttackController {

  #region Meus Métodos

  /**
   * Esse tipo de nave atira cinco tiros
   */
  protected override void shootAppropriateNumberOfShoots () {
    instantiateAndMoveBullet(shootPositions[0], Vector3.down);
    instantiateAndMoveBullet(shootPositions[1], Vector3.down);
    instantiateAndMoveBullet(shootPositions[2], Vector3.down);
    instantiateAndMoveBullet(shootPositions[3], Vector3.down);
    instantiateAndMoveBullet(shootPositions[4], Vector3.down);
  }

  #endregion

}