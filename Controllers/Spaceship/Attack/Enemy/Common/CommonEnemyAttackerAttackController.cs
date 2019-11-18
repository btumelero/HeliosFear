using UnityEngine;

public class CommonEnemyAttackerAttackController : EnemyAttackController {

  #region Meus Métodos

  /*
   * Esse tipo de nave atira três tiros que se espalham
   */
  protected override void shootAppropriateNumberOfShoots () {
    instantiateAndMoveBullet(shootPositions[0], Vector3.down);//baixo
    instantiateAndMoveBullet(shootPositions[1], new Vector3(-0.5f, -1));//baixo+esquerda
    instantiateAndMoveBullet(shootPositions[2], new Vector3(0.5f, -1));//baixo+direita
  }

  #endregion
}
