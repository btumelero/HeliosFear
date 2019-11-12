using UnityEngine;

public class BossEnemyDodgerAttackController : EnemyAttackController {

    #region Métodos da Unity

  /*
   * Start is called before the first frame update
   * Inicializa a velocidade e a potência base do tiro e randomiza o tempo entre disparos
   */
  protected override void Start () {
    base.Start();
    shootTimer.baseTime = Random.Range(1, 3);
    shootVelocity = 80;
    baseShootPower = 4;
  }

  #endregion

  #region Meus Métodos

  /*
   * Esse tipo de nave atira 
   */
  protected override void shootAppropriateNumberOfShoots () {
    //instantiateAndMoveBullet(shootPositions[0], Vector3.down);
    //instantiateAndMoveBullet(shootPositions[1], Vector3.down);
  }
  
  #endregion

}