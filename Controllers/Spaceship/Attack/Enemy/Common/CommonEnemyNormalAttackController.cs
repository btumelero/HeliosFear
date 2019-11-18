using UnityEngine;

public class CommonEnemyNormalAttackController : EnemyAttackController {

  #region Meus Métodos

  /*
   * Esse tipo de nave atira dois tiros para baixo
   * Retorna verdadeiro se atirou
   */
  protected override void shootAppropriateNumberOfShoots () {
    instantiateAndMoveBullet(shootPositions[0], Vector3.down);
    instantiateAndMoveBullet(shootPositions[1], Vector3.down);
  }
  
  #endregion

}
