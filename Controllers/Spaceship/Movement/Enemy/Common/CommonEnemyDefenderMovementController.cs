using UnityEngine;

public class CommonEnemyDefenderMovementController : EnemyMovementController {

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
    spaceship.velocity = new Vector3(
      0,
      (Time.fixedDeltaTime * 3) * (moving == Enums.Movement.Downward ? -actualSpeed : 0),
      0
    );
  }

  #endregion

}
