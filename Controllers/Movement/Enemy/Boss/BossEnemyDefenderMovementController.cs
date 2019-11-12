using UnityEngine;

public class BossEnemyDefenderMovementController : EnemyMovementController {

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
   * Dá uma direção inicial e randomiza a velocidade e tempo entre troca de direção para essa nave
   */
  protected override void Start () {
    base.Start();
    switchTimer.baseTime = Random.Range(3, 6);
    baseSpeed = 100;
  }

  #endregion

}
