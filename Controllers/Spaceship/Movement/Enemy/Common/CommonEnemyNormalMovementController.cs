using Enums;
using UnityEngine;

public class CommonEnemyNormalMovementController : CommonEnemyMovementController {

  #region Métodos da Unity

  public override void OnBecameInvisible () {
    base.OnBecameInvisible();
    Pool.store((byte) Spaceships.Normal, gameObject);
  }

  #endregion

  #region Meus métodos

  /*
   * Esse tipo de nave normal se move para esquerda, direita e baixo.
   * Esse método randomiza entre as três.
   * Move a nave na diagonal para esquerda e direita, mantendo o eixo profundidade como zero
   */
  public override void directionSwitch () {
    moving = (Enums.Movement) Random.Range(0, 3);
  }

  protected override void updateMovementDirection () {
    spaceshipBody.velocity = new Vector3(
      (Time.fixedDeltaTime * 3) * (
        moving == Enums.Movement.Downward ? 0 : moving == Enums.Movement.Rightward ? _actualSpeed : -_actualSpeed
      ),
      -_actualSpeed * (Time.fixedDeltaTime * 3),
      0
    );
  }

  #endregion

}
