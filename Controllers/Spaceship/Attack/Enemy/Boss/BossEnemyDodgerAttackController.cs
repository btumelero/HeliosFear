using UnityEngine;

public class BossEnemyDodgerAttackController : EnemyAttackController {

  #region Meus Métodos

  /*
   * Esse tipo de nave atira 
   */
  protected override void shootAppropriateNumberOfShoots () {
    //instantiateAndMoveBullet(shootPositions[0], Vector3.down);
    //instantiateAndMoveBullet(shootPositions[1], Vector3.down);
  }
  
  #endregion

}