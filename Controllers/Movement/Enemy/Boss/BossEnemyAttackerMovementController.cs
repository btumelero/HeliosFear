using UnityEngine;

public class BossEnemyAttackerMovementController : EnemyMovementController {

  #region Meus métodos

  /*
   * 
   */
  public override void directionSwitch () {
    
  }

  /*
   * 
   */
  protected override void updateMovementDirection () {
    
  }

  #endregion

  #region Métodos da Unity

  
  protected override void FixedUpdate () {
    base.FixedUpdate();
  }

  /*
   * Start is called before the first frame update
   * Dá uma velocidade e tempo entre troca de direção random inicial para essa nave
   */
  protected override void Start () {
    base.Start();
    switchTimer.baseTime = Random.Range(3, 5);
    baseSpeed = 125;
  }

  #endregion

}
