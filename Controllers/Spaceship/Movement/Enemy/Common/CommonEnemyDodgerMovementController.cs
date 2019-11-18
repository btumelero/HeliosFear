using UnityEngine;

public class CommonEnemyDodgerMovementController : EnemyMovementController {

  #region Meus métodos

  /*
   * Esse tipo de nave se move para esquerda e direita.
   * Esse método randomiza entre os dois
   * Move a nave para baixo e esquerda ou direita e mantém o eixo profundidade como zero
   */
  public override void directionSwitch () {
    moving = (movementType) Random.Range(0, 2);
  }

  protected override void updateMovementDirection () {
    spaceship.velocity = new Vector3(
      (Time.fixedDeltaTime * 3) * (moving == movementType.RIGHTWARD ? actualSpeed : -actualSpeed),
      -actualSpeed * (Time.fixedDeltaTime * 3),
      0
    );
  }

  #endregion

}
