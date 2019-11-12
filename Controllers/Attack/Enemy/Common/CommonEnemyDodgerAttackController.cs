using UnityEngine;

public class EnemyDodgerAttackController : EnemyAttackController {

  #region Métodos da Unity

  /*
   * Start is called before the first frame update
   * Inicializa a velocidade e a potência base do tiro e randomiza o tempo entre disparos
   */
  protected override void Start () {
    base.Start();
    shootTimer.baseTime = Random.Range(2, 4);
    shootVelocity = 40;
    baseShootPower = 2;
  }

  #endregion

  #region

  /*
   * Esse tipo de nave atira um tiro para baixo
   */
  protected override void shootAppropriateNumberOfShoots () {
    instantiateAndMoveBullet(shootPositions[0], Vector3.down);
  }

  #endregion
}
