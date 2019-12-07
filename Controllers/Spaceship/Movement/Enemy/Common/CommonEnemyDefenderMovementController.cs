using Enums;
using UnityEngine;

public class CommonEnemyDefenderMovementController : CommonEnemyMovementController {

  #region Métodos da Unity

  public override void OnBecameInvisible () {
    base.OnBecameInvisible();
    Pool.store((byte) Spaceships.Defender, gameObject);
  }

  #endregion

  #region Meus métodos

  /*
   * Esse tipo de nave defender se move para baixo ou fica parada.
   * Esse método randomiza entre os dois
   * Move a nave para baixo e mantém os eixos profundidade e horizontal como zero
   */
  public override void directionSwitch () {
    moving = (Enums.Movement) Random.Range(2, 4);
  }

  protected override void updateMovementDirection () {
    spaceshipBody.velocity = new Vector3(
      0,
      (Time.fixedDeltaTime * 3) * (moving == Enums.Movement.Downward ? -_actualSpeed : 0),
      0
    );
  }

  #endregion

}
