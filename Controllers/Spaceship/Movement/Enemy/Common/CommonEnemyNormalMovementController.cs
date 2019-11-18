using UnityEngine;

public class CommonEnemyNormalMovementController : EnemyMovementController {

  #region Meus métodos

  /*
   * Esse tipo de nave normal se move para esquerda, direita e baixo.
   * Esse método randomiza entre as três.
   * Move a nave na diagonal para esquerda e direita, mantendo o eixo profundidade como zero
   */
  public override void directionSwitch () {
    moving = (movementType) Random.Range(0, 3);
  }

  protected override void updateMovementDirection () {
    spaceship.velocity = new Vector3(
      (Time.fixedDeltaTime * 3) * (moving == movementType.DOWNWARD ? 0 : moving == movementType.RIGHTWARD ? actualSpeed : -actualSpeed),
      -actualSpeed * (Time.fixedDeltaTime * 3),
      0
    );
  }

  #endregion

}
