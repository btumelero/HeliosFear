using UnityEngine;

public class CommonEnemyDodgerAttackController : EnemyAttackController {

  #region

  /*
   * Esse tipo de nave atira um tiro para baixo
   */
  protected override void shootAppropriateNumberOfShoots () {
    instantiateAndMoveBullet(shootPositions[0], Vector3.down);
  }

  #endregion

}
