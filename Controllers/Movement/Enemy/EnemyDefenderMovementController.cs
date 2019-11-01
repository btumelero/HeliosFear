using UnityEngine;

public class EnemyDefenderMovementController : EnemyMovementController {

  #region Meus métodos

  /*
   * Esse tipo de nave defender se move para baixo ou fica parada.
   * Esse método randomiza entre os dois
   * Move a nave para baixo e mantém os eixos profundidade e horizontal como zero
   */
  public override void directionSwitch () {
    moving = (movementType) Random.Range(2, 4);
  }

  protected override void updateMovementDirection () {
    spaceship.velocity = new Vector3(
      0,
      (Time.fixedDeltaTime * 3) * (moving == movementType.DOWNWARD ? -actualSpeed : 0),
      0
    );
  }

  #endregion

  #region Métodos da Unity

  /*
   * Start is called before the first frame update
   * Dá uma direção inicial e randomiza a velocidade e tempo entre troca de direção para essa nave
   */
  protected override void Start () {
    base.Start();
    switchTimer.baseTime = Random.Range(3, 6);
    baseSpeed = 100;
  }

  #endregion

}
