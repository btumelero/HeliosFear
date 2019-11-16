using UnityEngine;

public class BossEnemyDodgerMovementController : EnemyMovementController {

  #region Meus métodos

  /*
   * 
   */
  public override void directionSwitch () {

  }

  protected override void updateMovementDirection () {
      
  }

  #endregion

  #region Métodos da Unity

  /*
   * Start is called before the first frame update
   * Dá uma direção, velocidade e tempo entre troca de direção random inicial para essa nave
   */
  protected override void Start () {
    base.Start();
    switchTimer.baseTime = Random.Range(2, 4);
    baseSpeed = 200;
  }

  #endregion
}
